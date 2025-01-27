using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Application.Interfaces.InterfacesPeople;
using DNC.ProjectAudit.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DNCProjectAuditContext ctxt;
        private readonly ICEORepository cEORepository;
        private readonly IAuditorRepository auditorRepository;
        private readonly IProjectManagerRepository projectManagerRepository;
        private readonly ISupervisorRepository supervisorRepository;

        private readonly IAuditQuestionnaireRepository auditQuestionnaireRepository;
        private readonly IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository;
        private readonly IOpenQuestionRepository openQuestionRepository;
        private readonly ISelectListQuestionRepository selectListQuestionRepository;

        public UnitofWork(DNCProjectAuditContext ctxt, ICEORepository cEORepository, IAuditorRepository auditorRepository, IProjectManagerRepository projectManagerRepository, ISupervisorRepository supervisorRepository, 
            IAuditQuestionnaireRepository auditQuestionnaireRepository, IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IOpenQuestionRepository openQuestionRepository, ISelectListQuestionRepository selectListQuestionRepository)
        {
            this.ctxt = ctxt;
            this.cEORepository = cEORepository;
            this.auditorRepository = auditorRepository;
            this.projectManagerRepository = projectManagerRepository;
            this.supervisorRepository = supervisorRepository;

            this.auditQuestionnaireRepository = auditQuestionnaireRepository;
            this.multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            this.openQuestionRepository = openQuestionRepository;
            this.selectListQuestionRepository = selectListQuestionRepository;
        }

        public IAuditorRepository AuditorRepository => auditorRepository;

        public ICEORepository ICEORepository => cEORepository;

        public IProjectManagerRepository ProjectManagerRepository => projectManagerRepository;

        public ISupervisorRepository SupervisorRepository => supervisorRepository;

        public IAuditQuestionnaireRepository AuditQuestionnaireRepository => auditQuestionnaireRepository;

        public IMultipleChoiceQuestionRepository MultipleChoiceQuestionRepository => multipleChoiceQuestionRepository;

        public IOpenQuestionRepository OpenQuestionRepository => openQuestionRepository;

        public ISelectListQuestionRepository SelectListQuestionRepository => selectListQuestionRepository;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
