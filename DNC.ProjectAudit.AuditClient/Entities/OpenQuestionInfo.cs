namespace DNC.ProjectAudit.AuditClient.Entities
{
    public class OpenQuestionInfo
    {
        public int Index { get; set; }
        public String? QuestionText { get; set; }
        public string? AnswerText { get; set; }
        public bool? IsDisplay { get; set; }
        public int PriorityIndication { get; set; }
    }
}
