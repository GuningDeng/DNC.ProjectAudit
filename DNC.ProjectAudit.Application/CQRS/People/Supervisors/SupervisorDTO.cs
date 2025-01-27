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
    public class SupervisorDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public Region Region { get; set; }
        public int SupervisorProjectManagerId { get; set; }
        //public int SupervisorAuditQuestionnaireId { get; set; }
        [JsonIgnore]
        public ProjectManager? SupervisorProjectManager { get; set; }
        [JsonIgnore]
        public AuditQuestionnaire? SupervisorAuditQuestionnaire { get; set; }
    }
}
