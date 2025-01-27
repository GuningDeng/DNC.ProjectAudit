using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Application.Interfaces.InterfacesPeople;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces
{
    public interface IUnitofWork
    {
        public IAuditorRepository AuditorRepository { get; }
        public ICEORepository ICEORepository { get; }
        public IProjectManagerRepository ProjectManagerRepository { get; }
        public ISupervisorRepository SupervisorRepository { get; }

        public IAuditQuestionnaireRepository AuditQuestionnaireRepository { get; }
        public IMultipleChoiceQuestionRepository MultipleChoiceQuestionRepository { get; }
        public IOpenQuestionRepository OpenQuestionRepository { get; }
        public ISelectListQuestionRepository SelectListQuestionRepository { get; }

        Task Commit();
    }
}
