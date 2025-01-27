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
    public class SupervisorConfiguration : IEntityTypeConfiguration<Supervisor>
    {
        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.ToTable("tblSupervisor", "Supervisor")
                .HasKey(s => s.Id);
            builder.HasIndex(s => s.Id)
                .IsUnique();

            builder.Property(s => s.Id)
                .HasColumnType("int");

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(s => s.Role)
                .IsRequired()
                .HasColumnType("nvarchar(32)");

            builder.Property(s => s.Email)
                .HasColumnType("nvarchar(128)");

            builder.Property(s => s.OfficePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(s => s.MobilePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(s => s.IsActive)
                .HasColumnType("bit");

            builder.Property(s => s.Region)
                .HasColumnType("nvarchar(64)");

            builder.Property(s => s.SupervisorProjectManagerId)
                .HasColumnType("int");
        }
    }
}
