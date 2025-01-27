using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Seeding
{
    public static class AuditorSeeding
    {
        public static void Seed(this EntityTypeBuilder<Auditor> modelBuilder)
        {
            modelBuilder.HasData(
                new Auditor()
                {
                    Id = 2,
                    FirstName = "Jan",
                    LastName = "Janssen",
                    Role = Role.Auditor,
                    Email = "janjanssen@dnc.com",
                    OfficePhone = "+32222222",
                    MobilePhone = "+32488222333",
                    IsActive = true,
                }
                );
        }
    }
}
