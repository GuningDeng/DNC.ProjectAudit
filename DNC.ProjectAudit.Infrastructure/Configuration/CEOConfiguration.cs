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
    public class CEOConfiguration : IEntityTypeConfiguration<CEO>
    {
        public void Configure(EntityTypeBuilder<CEO> builder)
        {
            builder.ToTable("tblCEO", "CEO")
                .HasKey(c => c.Id);
            builder.HasIndex(c => c.Id)
                .IsUnique();

            builder.Property(c => c.Id)
                .HasColumnType("int");

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(128)");

            builder.Property(c => c.Role)
                .IsRequired()
                .HasColumnType("nvarchar(32)");

            builder.Property(c => c.Email)
                .HasColumnType("nvarchar(128)");

            builder.Property(c => c.OfficePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(c => c.MobilePhone)
                .HasColumnType("nvarchar(32)");

            builder.Property(c => c.IsActive)
                .HasColumnType("bit");

            builder.Property(c => c.Phone)
                .HasColumnType("nvarchar(32)");

            builder.Property(c => c.AssistantPhone)
                .HasColumnType("nvarchar(32)");



        }
    }
    
}
