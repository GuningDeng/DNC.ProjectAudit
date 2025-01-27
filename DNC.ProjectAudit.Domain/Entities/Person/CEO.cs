using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.Person
{
    public class CEO : Person
    {
        public string? Phone { get; set; }
        public string? AssistantPhone { get; set; }
        
    }
}
