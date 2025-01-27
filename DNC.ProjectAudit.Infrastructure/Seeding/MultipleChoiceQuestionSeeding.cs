using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Seeding
{
    public static class MultipleChoiceQuestionSeeding
    {
        public static void Seed(this EntityTypeBuilder<MultipleChoiceQuestion> modelBuilder)
        {
            modelBuilder.HasData(
                new MultipleChoiceQuestion()
                {
                    Id = 1,
                    QuestionText = "Materiaalleverancier voor dit project:",
                    OptionText = "BBA;BASF;HoutVlaanderen",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,
                },
                new MultipleChoiceQuestion()
                {
                    Id = 2,
                    QuestionText = "De regio waar de materiaalleverancier van dit project gevestigd is",
                    OptionText = "EU;België;Antwerpen;Brussel;Gent;Luik;Andere regions",
                    AnswerText = "NoValue",
                    IsDisplay = true,
                    PriorityIndication = 1,
                    QuestionAuditQuestionnaireId = 1,
                }
                );
        }
    }
}
