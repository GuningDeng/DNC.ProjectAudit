using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using DNC.ProjectAudit.Application.CQRS.People.ProjectManagers;
using DNC.ProjectAudit.Application.CQRS.People.Supervisors;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits
{
    public class AuditQuestionnaireDetailDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Region Region { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SubmissionDeadline { get; set; }
        /// <summary>
        /// formate: "name-id;name-id;name-id" 
        /// </summary>
        public string? SubmittedBySupervisorsText { get; set; }
        /// <summary>
        /// The project manager Id who approved the questionnaire
        /// </summary>
        public int ApprovedByProjetManagerId { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        //public int AuditorId { get; set; }
        [JsonIgnore]
        public Auditor? QuestionnaireAuditor { get; set; }

        [JsonIgnore]
        public ICollection<MultipleChoiceQuestionDTO>? MultipleChoiceQuestions { get; set; }

        [JsonIgnore]
        public ICollection<OpenQuestionDTO>? OpenQuestions { get; set; }
        [JsonIgnore]
        public ICollection<SelectListQuestionDTO>? SelectListQuestions { get; set; }
        [JsonIgnore]
        public ProjectManagerDetailDTO? QuestionnaireProjectManager { get; set; }
        [JsonIgnore]
        public ICollection<SupervisorDetailDTO>? Supervisors { get; set; }
    }
}
