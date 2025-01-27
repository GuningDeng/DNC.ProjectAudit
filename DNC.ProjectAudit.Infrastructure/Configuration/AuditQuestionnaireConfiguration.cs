using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using DNC.ProjectAudit.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Configuration
{
    public class AuditQuestionnaireConfiguration : IEntityTypeConfiguration<AuditQuestionnaire>
    {
        public void Configure(EntityTypeBuilder<AuditQuestionnaire> builder)
        {
            builder.ToTable("tblAuditQuestionnaire", "AuditQuestionnaire")
                .HasKey(a => a.Id);
            builder.HasIndex(a => a.Name)
                .IsUnique();

            builder.Property(a => a.Id)
                .HasColumnType("int");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            builder.Property(a => a.Description)
                .HasColumnType("nvarchar(512)");

            builder.Property(a => a.Region)
                .HasColumnType("nvarchar(64)");

            builder.Property(a => a.CreatedBy)
                .HasColumnType("int");

            builder.Property(a => a.UpdatedBy)
                .HasColumnType("int");

            builder.Property(a => a.DeletedBy)
                .HasColumnType("int");

            builder.Property(a => a.CreatedDate)
                .HasColumnType("datetime");

            builder.Property(a => a.SubmissionDeadline)
                .HasColumnType("datetime");

            builder.Property(a => a.SubmittedBySupervisorsText)
                .HasColumnType("nvarchar(2048)");

            builder.Property(a => a.ApprovedByProjetManagerId)
                .HasColumnType("int");

            builder.Property(a => a.IsStarted)
                .HasColumnType("bit");

            builder.Property(a => a.IsCompleted)
                .HasColumnType("bit");

            builder.HasMany(a => a.MultipleChoiceQuestions).WithOne(m => m.QuestionAuditQuestionnaire);

            builder.HasMany(a => a.OpenQuestions).WithOne(o => o.QuestionAuditQuestionnaire);

            builder.HasMany(a => a.SelectListQuestions).WithOne(s => s.QuestionAuditQuestionnaire);

            builder.HasMany(a => a.Supervisors).WithOne(s => s.SupervisorAuditQuestionnaire);

            builder.HasOne(a => a.QuestionnaireProjectManager).WithOne(p => p.ProjectManagerAuditQuestionnaire);

        }
    }
}
