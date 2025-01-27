using DNC.ProjectAudit.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.Person
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public string? MobilePhone { get; set; }
        public bool IsActive { get; set; }
    }
}
