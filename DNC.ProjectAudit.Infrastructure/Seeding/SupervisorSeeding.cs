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
    public static class SupervisorSeeding
    {
        public static void Seed(this EntityTypeBuilder<Supervisor> modelBuilder)
        {
            modelBuilder.HasData(
                new Supervisor()
                {
                    Id = -2,
                    FirstName = "Christ",
                    LastName = "Brown",
                    Role = Role.Supervisor,
                    Email = "christbrown@dnc.com",
                    OfficePhone = "+32555333",
                    MobilePhone = "+32486555222",
                    Region = Region.Brussels,
                    IsActive = true,
                    SupervisorProjectManagerId = 3,
                }
                );
        }
    }
}
