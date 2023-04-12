namespace WordEvaluatorMSSQL.Models
{
    public class Word : BaseDbModel
    {
        public Guid WordSetId { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
