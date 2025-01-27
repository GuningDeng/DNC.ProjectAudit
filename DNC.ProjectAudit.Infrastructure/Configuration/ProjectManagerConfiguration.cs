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
    public class ProjectManagerConfiguration : IEntityTypeConfiguration<ProjectManager>
    {
        public void Configure(EntityTypeBuilder<ProjectManager> builder)
        {
            builder.ToTable("tblProjectManager", "ProjectManager")
                .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                .IsUnique();

            builder.Property(p => p.Id)
                .HasColumnType("int");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(p => p.Role)
                .IsRequired()
                .HasColumnType("nvarchar(32)");

            builder.Property(p => p.Email)
                .HasColumnType("nvarchar(128)");

            builder.Property(p => p.OfficePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(p => p.MobilePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(p => p.IsActive)
                .HasColumnType("bit");

            builder.Property(p => p.Region)
                .HasColumnType("nvarchar(64)");

            builder.Property(p => p.ProjectManagerAuditQuestionnaireId)
                .HasColumnType("int");

            builder.HasMany(p => p.ProjectManagerSupervisors).WithOne(s => s.SupervisorProjectManager);

        }
    }
}
