namespace DNC.ProjectAudit.AuditClient.Entities
{
    public class QuestionWithOptionInfoList
    {
        public String? QuestionText { get; set; }
        public ICollection<OptionInfo>? Options { get; set; }
        public int Index { get; set; }
        public string? AnswerText { get; set; }
        public bool? IsDisplay { get; set; }
        public int PriorityIndication { get; set; }
    }
}
