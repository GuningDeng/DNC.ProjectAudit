using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Configuration
{
    public class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder.ToTable("tblMultipleChoiceQuestion", "MultipleChoiceQuestion")
                .HasKey(m => m.Id);
            builder.HasIndex(m => m.Id)
                .IsUnique();

            builder.Property(m => m.Id)
                .HasColumnType("int");

            builder.Property(m => m.QuestionText)
                .IsRequired()
                .HasColumnType("nvarchar(512)");

            builder.Property(m => m.AnswerText)
                .HasColumnType("nvarchar(32)");

            builder.Property(m => m.IsDisplay)
                .HasColumnType("bit");

            builder.Property(m => m.PriorityIndication)
                .HasColumnType("int");

            builder.Property(m => m.OptionText)
                .IsRequired()
                .HasColumnType("nvarchar(2048)");

            builder.Property(m => m.QuestionAuditQuestionnaireId)
                .HasColumnType("int");
        }
    }
}
