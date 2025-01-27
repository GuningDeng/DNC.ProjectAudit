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
    public class AuditorConfiguration : IEntityTypeConfiguration<Auditor>
    {
        public void Configure(EntityTypeBuilder<Auditor> builder)
        {
            builder.ToTable("tblAuditor", "Auditor")
                .HasKey(a => a.Id);
            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.Property(a => a.Id)
                .HasColumnType("int");

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(a => a.Role)
                .IsRequired()
                .HasColumnType("nvarchar(32)");

            builder.Property(a => a.Email)
                .HasColumnType("nvarchar(128)");

            builder.Property(a => a.OfficePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(a => a.MobilePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(a => a.IsActive)
                .HasColumnType("bit");

            builder.HasMany(a => a.Questionnaires).WithOne(q => q.QuestionnaireAuditor);
        }
    }
}
