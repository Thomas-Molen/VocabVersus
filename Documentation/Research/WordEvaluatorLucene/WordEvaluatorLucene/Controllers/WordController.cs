using Microsoft.AspNetCore.Mvc;
using WordEvaluatorLucene.Lucene;
using WordEvaluatorLucene.Models;
using WordEvaluatorLucene.Models.Request;

namespace WordEvaluatorLucene.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController
    {
        private readonly WordEngine _wordEngine;
        public WordController(WordEngine wordEngine)
        {
            _wordEngine = wordEngine;
        }

        [HttpGet("details")]
        public ActionResult<bool> Exists(Guid wordSetId, string word)
        {
            return _wordEngine.HasWordMatch(wordSetId, word);
        }

        [HttpPost("insert")]
        public async Task<ActionResult> Insert(InsertWordsRequest request)
        {
            try
            {
                _wordEngine.AddWordsToIndex(request.WordSetId, request.Words.ToArray());
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
            
            return new OkResult();
        }
    }
}
