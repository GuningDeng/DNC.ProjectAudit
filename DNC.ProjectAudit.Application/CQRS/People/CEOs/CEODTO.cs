using DNC.ProjectAudit.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.People.CEOs
{
    public class CEODTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public string? MobilePhone { get; set; }
        public bool IsActive { get; set; }
        public string? AssistantPhone { get; set; }
    }
}
