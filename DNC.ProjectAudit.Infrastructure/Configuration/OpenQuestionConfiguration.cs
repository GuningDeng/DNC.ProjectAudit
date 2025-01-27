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
    public class OpenQuestionConfiguration : IEntityTypeConfiguration<OpenQuestion>
    {
        public void Configure(EntityTypeBuilder<OpenQuestion> builder)
        {
            builder.ToTable("tblOpenQuestion", "OpenQuestion")
                .HasKey(o => o.Id);
            builder.HasIndex(o => o.Id)
                .IsUnique();

            builder.Property(o => o.Id)
                .HasColumnType("int");

            builder.Property(o => o.QuestionText)
                .IsRequired()
                .HasColumnType("nvarchar(512)");

            builder.Property(o => o.AnswerText)
                .HasColumnType("nvarchar(2048)");

            builder.Property(o => o.IsDisplay)
                .HasColumnType("bit");

            builder.Property(o => o.PriorityIndication)
                .HasColumnType("int");

            builder.Property(o => o.QuestionAuditQuestionnaireId)
                .HasColumnType("int");
        }
    }
}
