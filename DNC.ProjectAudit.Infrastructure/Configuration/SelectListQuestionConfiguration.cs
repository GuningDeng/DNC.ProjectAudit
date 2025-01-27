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
    public class SelectListQuestionConfiguration : IEntityTypeConfiguration<SelectListQuestion>
    {
        public void Configure(EntityTypeBuilder<SelectListQuestion> builder)
        {
            builder.ToTable("tblSelectListQuestion", "SelectListQuestion")
                .HasKey(s => s.Id);
            builder.HasIndex(s => s.Id)
                .IsUnique();

            builder.Property(s => s.Id)
                .HasColumnType("int");

            builder.Property(s => s.QuestionText)
                .IsRequired()
                .HasColumnType("nvarchar(512)");

            builder.Property(s => s.AnswerText)
                .HasColumnType("nvarchar(2048)");

            builder.Property(s => s.IsDisplay)
                .HasColumnType("bit");

            builder.Property(s => s.PriorityIndication)
                .HasColumnType("int");

            builder.Property(s => s.OptionText)
                .IsRequired()
                .HasColumnType("nvarchar(1024)");

            builder.Property(s => s.QuestionAuditQuestionnaireId)
                .HasColumnType("int");

        }
    }
}
