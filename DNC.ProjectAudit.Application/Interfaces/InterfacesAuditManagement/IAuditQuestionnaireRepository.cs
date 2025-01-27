using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement
{
    public interface IAuditQuestionnaireRepository : IGenericRepository<AuditQuestionnaire>
    {
        Task<PagedResult<AuditQuestionnaire>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10); 
        AuditQuestionnaire GetByTitle(string title);
        Task<IEnumerable<AuditQuestionnaire>> GetAllAuditQuestionnaires();
        Task<IEnumerable<AuditQuestionnaire>> GetAuditQuestionnairesByRegion(Region region);
    }
}
