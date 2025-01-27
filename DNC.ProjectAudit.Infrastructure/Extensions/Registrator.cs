using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Application.Interfaces.InterfacesPeople;
using DNC.ProjectAudit.Infrastructure.Contexts;
using DNC.ProjectAudit.Infrastructure.Repositories.AuditRepositories;
using DNC.ProjectAudit.Infrastructure.Repositories.PeopleRepositories;
using DNC.ProjectAudit.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DNCProjectAuditContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:DNCProjectAudit"));
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuditorRepository, AuditorRepository>();
            services.AddScoped<ICEORepository, CEORepository>();
            services.AddScoped<IProjectManagerRepository, ProjectManagerRepository>();
            services.AddScoped<ISupervisorRepository, SupervisorRepository>();

            services.AddScoped<IAuditQuestionnaireRepository, AuditQuestionnaireRepository>();
            services.AddScoped<IMultipleChoiceQuestionRepository, MultipleChoiceQuestionRepository>();
            services.AddScoped<IOpenQuestionRepository, OpenQuestionRepository>();
            services.AddScoped<ISelectListQuestionRepository, SelectListQuestionRepository>();
            
            services.AddScoped<IUnitofWork, UnitofWork>();

            return services;
        }
    }
}
