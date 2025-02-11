namespace DNC.ProjectAudit.AuditClient.Entities
{
    public class QuestionnaireInfo
    {
        public String? Name { get; set; }
        public ICollection<QuestionWithOptionInfoList>? MultipleChoiceInfos { get; set; }
        public ICollection<QuestionWithOptionInfoList>? SelectListInfos { get; set; }
        public ICollection<OpenQuestionInfo>? OpenQuestionInfos { get; set; }
    }
}
