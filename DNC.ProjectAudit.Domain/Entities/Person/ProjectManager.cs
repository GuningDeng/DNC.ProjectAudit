using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.Person
{
    public class ProjectManager : Person
    {
        public Region Region { get; set; }
        public int ProjectManagerAuditQuestionnaireId { get; set; }

        [JsonIgnore]
        public ICollection<Supervisor>? ProjectManagerSupervisors { get; set; }
        [JsonIgnore]
        public AuditQuestionnaire? ProjectManagerAuditQuestionnaire { get; set; }
    }
}
