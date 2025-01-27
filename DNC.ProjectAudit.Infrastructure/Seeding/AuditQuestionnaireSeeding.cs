using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Seeding
{
    public static class AuditQuestionnaireSeeding
    {
        public static void Seed(this EntityTypeBuilder<AuditQuestionnaire> modelBuilder)
        {
            modelBuilder.HasData(
                new AuditQuestionnaire()
                {
                    Id = 1,
                    Name = "DNC_BlueLine_Brussele",
                    Description = "DNC, Project name, Region",
                    Region = Region.Brussels,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    SubmissionDeadline = DateTime.Now.AddDays(7),
                    IsStarted = false,
                    IsCompleted = false,

                },
                new AuditQuestionnaire()
                {
                    Id = 2,
                    Name = "DNC_RedLine_Brussele",
                    Description = "DNC, Project name, Region",
                    Region = Region.Antwerp,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    SubmissionDeadline = DateTime.Now.AddDays(7),
                    IsStarted = false,
                    IsCompleted = false,
                }
                );
        }
    }
}
