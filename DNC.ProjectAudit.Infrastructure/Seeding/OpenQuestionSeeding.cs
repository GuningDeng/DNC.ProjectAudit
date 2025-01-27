using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Seeding
{
    public static class OpenQuestionSeeding
    {
        public static void Seed(this EntityTypeBuilder<OpenQuestion> modelBuilder)
        {
            modelBuilder.HasData(
                new OpenQuestion()
                {
                    Id = 1,
                    QuestionText = "Beschrijf uw missie.",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,

                },
                new OpenQuestion()
                {
                    Id = 2,
                    QuestionText = "Beschrijf het project.",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,
                }
                );
        }
    }
}
