using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using DNC.ProjectAudit.Domain.Entities.Person;
using DNC.ProjectAudit.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Contexts
{
    public class DNCProjectAuditContext : DbContext
    {
        public DNCProjectAuditContext(DbContextOptions<DNCProjectAuditContext> options) : base(options)
        {
        }

        public DbSet<CEO> CEOs { get; set; }
        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<AuditQuestionnaire> AuditQuestionnaires { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<SelectListQuestion> SelectListQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Auditor>().Seed();
            modelBuilder.Entity<CEO>().Seed();
            modelBuilder.Entity<ProjectManager>().Seed();
            modelBuilder.Entity<Supervisor>().Seed();
            modelBuilder.Entity<AuditQuestionnaire>().Seed();
            modelBuilder.Entity<MultipleChoiceQuestion>().Seed();
            modelBuilder.Entity<OpenQuestion>().Seed();
            modelBuilder.Entity<SelectListQuestion>().Seed();

        }
    }
}
