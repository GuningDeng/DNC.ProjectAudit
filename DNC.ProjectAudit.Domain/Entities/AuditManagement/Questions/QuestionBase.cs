using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions
{
    public class QuestionBase
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }
        public bool? IsDisplay { get; set; }
        public int PriorityIndication { get; set; }

        public int QuestionAuditQuestionnaireId { get; set; }
        [JsonIgnore]
        public AuditQuestionnaire? QuestionAuditQuestionnaire { get; set; }

    }
}
