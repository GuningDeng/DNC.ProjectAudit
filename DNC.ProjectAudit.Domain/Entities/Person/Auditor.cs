using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.Person
{
    public class Auditor : Person
    {
        [JsonIgnore]
        public ICollection<AuditQuestionnaire>? Questionnaires { get; set; } 
    }
}
