namespace WordEvaluatorMSSQL.Models.Request
{
    public class InsertWordsRequest
    {
        public Guid WordSetId { get; set; }
        public List<string> Words{ get; set; } = new();
    }
}
