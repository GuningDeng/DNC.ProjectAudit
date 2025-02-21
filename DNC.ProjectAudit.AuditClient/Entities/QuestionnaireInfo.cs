using DNC.ProjectAudit.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DNC.ProjectAudit.AuditClient.Entities
{
    public class QuestionnaireInfo
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        [StringLength(32, ErrorMessage = "Naam mag niet langer zijn dan 100 tekens.")]
        public String? Name { get; set; }
        [Required(ErrorMessage = "Beschrijving is verplicht.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Gewest is verplicht.")]
        public Region Region { get; set; }
        [Required(ErrorMessage = "Deadline voor inzending is verlicht.")]
        [DataType(DataType.Date)]
        public DateTime SubmissionDeadline { get; set; } = DateTime.Now;
        public ICollection<QuestionWithOptionInfoList>? MultipleChoiceInfos { get; set; }
        public ICollection<QuestionWithOptionInfoList>? SelectListInfos { get; set; }
        public ICollection<OpenQuestionInfo>? OpenQuestionInfos { get; set; }
    }
}
