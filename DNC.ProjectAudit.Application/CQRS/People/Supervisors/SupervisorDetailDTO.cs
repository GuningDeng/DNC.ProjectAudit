using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.People.Supervisors
{
    public class SupervisorDetailDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public string? MobilePhone { get; set; }
        public bool IsActive { get; set; }
        public Region Region { get; set; }
        public int SupervisorProjectManagerId { get; set; }
        //public int SupervisorAuditQuestionnaireId { get; set; }
        [JsonIgnore]
        public ProjectManager? SupervisorProjectManager { get; set; }
        [JsonIgnore]
        public AuditQuestionnaire? SupervisorAuditQuestionnaire { get; set; }
    }
}
