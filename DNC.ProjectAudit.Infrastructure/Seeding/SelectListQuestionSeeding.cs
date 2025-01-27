using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Seeding
{
    public static class SelectListQuestionSeeding
    {
        public static void Seed(this EntityTypeBuilder<SelectListQuestion> modelBuilder)
        {
            modelBuilder.HasData(
                new SelectListQuestion()
                {
                    Id = 1,
                    QuestionText = "Staalsoort gebruikt in project:",
                    OptionText = "S235;S275;S355",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,
                },
                new SelectListQuestion()
                {
                    Id = 2,
                    QuestionText = "Type transportvoertuig dat in het project wordt gebruikt:",
                    OptionText = "Wagen;Vrachtwagen;Aanhangwagen;Bus",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,
                }
                );
        }
    }
}
