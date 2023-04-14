using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using WordEvaluatorLucene.Models;
using Lucene.Net.Util;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Lucene.Net.QueryParsers.Classic;
using System.Text;
using Lucene.Net.Analysis.Miscellaneous;
using Microsoft.Extensions.ObjectPool;

namespace WordEvaluatorLucene.Lucene
{
    public class WordEngine
    {
        private readonly LuceneVersion _version;
        private readonly StandardAnalyzer _analyzer;
        private readonly FSDirectory _directory;
        private readonly IndexWriter _writer;

        public WordEngine()
        {
            _version = LuceneVersion.LUCENE_48;
            _analyzer = new StandardAnalyzer(_version);
            _directory = FSDirectory.Open("lucenedb");
            var config = new IndexWriterConfig(_version, _analyzer);
            _writer = new IndexWriter(_directory, config);
        }

        public void AddWordsToIndex(Guid wordSetId, params string[] words)
        {
            var builder = new StringBuilder();
            builder.AppendJoin<string>(' ', words);
            var document = new Document
                {
                    new StringField("WordSetId", wordSetId.ToString(), Field.Store.YES),
                    new TextField("Words", builder.ToString(), Field.Store.NO)
                };
            _writer.AddDocument(document);
            _writer.Commit();
        }

        public bool HasWordMatch(Guid wordSetId, string word)
        {
            var directoryReader = DirectoryReader.Open(_directory);
            var indexSearcher = new IndexSearcher(directoryReader);

            string[] fields = { "WordSetId", "Words" };
            var queryParser = new MultiFieldQueryParser(_version, fields, _analyzer);
            queryParser.AllowLeadingWildcard = true;

            // Remove whitespaces to avoid dubble word matching
            word = string.Concat(word.Where(c => !Char.IsWhiteSpace(c)));

            // Create search queries
            Query WordSetQuery = new TermQuery(new Term("WordSetId", wordSetId.ToString()));
            Query WordQuery = new TermQuery(new Term("Words", word));

            BooleanQuery query = new BooleanQuery();
            query.Add(WordSetQuery, Occur.MUST);
            query.Add(WordQuery, Occur.MUST);

            // if a signle match was found, return true
            return indexSearcher.Search(query, 1).TotalHits > 0;
        }
    }
}
