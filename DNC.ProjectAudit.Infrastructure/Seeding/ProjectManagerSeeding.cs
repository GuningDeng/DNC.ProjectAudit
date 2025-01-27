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
    public static class ProjectManagerSeeding
    {
        public static void Seed(this EntityTypeBuilder<ProjectManager> modelBuilder)
        {
            modelBuilder.HasData(
                new ProjectManager()
                {
                    Id = 3,
                    FirstName = "Bruno",
                    LastName = "Peeters",
                    Role = Role.ProjectManager,
                    Email = "brunopeeters@dnc.com",
                    OfficePhone = "+32333222",
                    MobilePhone = "+32486111333",
                    Region = Region.Brussels,
                    IsActive = true,
                    ProjectManagerAuditQuestionnaireId = 1
                },
                new ProjectManager()
                {
                    Id = 4,
                    FirstName = "Aan",
                    LastName = "van Anders",
                    Role = Role.ProjectManager,
                    Email = "aanvananders@dnc.com",
                    OfficePhone = "+32333555",
                    MobilePhone = "+32486111555",
                    Region = Region.Antwerp,
                    IsActive = true,
                    ProjectManagerAuditQuestionnaireId = 2
                }
                );
        }
    }
}
