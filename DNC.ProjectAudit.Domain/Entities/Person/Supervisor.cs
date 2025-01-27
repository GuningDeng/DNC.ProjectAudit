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
    public class Supervisor : Person
    {
        public Region Region { get; set; }

        public int SupervisorProjectManagerId { get; set; }
        //public int SupervisorAuditQuestionnaireId { get; set; }
        [JsonIgnore]
        public ProjectManager? SupervisorProjectManager { get; set; }
        [JsonIgnore]
        public AuditQuestionnaire? SupervisorAuditQuestionnaire { get; set; }

    }
}
