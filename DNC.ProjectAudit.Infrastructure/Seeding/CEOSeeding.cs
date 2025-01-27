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
    public static class CEOSeeding
    {
        public static void Seed(this EntityTypeBuilder<CEO> modelBuilder)
        {
            modelBuilder.HasData(
                new CEO()
                {
                    Id = 1,
                    FirstName = "Guning",
                    LastName = "Deng",
                    Role = Role.CEO,
                    Email = "guningdeng@dnc.com",
                    OfficePhone = "+32111111",
                    MobilePhone = "+32486333888",
                    IsActive = true,
                    Phone = "+32222222",
                    AssistantPhone = "+32111999"

                }
                );
        }
    }
}
