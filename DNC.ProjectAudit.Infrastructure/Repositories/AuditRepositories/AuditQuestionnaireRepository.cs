using DNC.ProjectAudit.Application;
using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Repositories.AuditRepositories
{
    public class AuditQuestionnaireRepository : GenericRepository<AuditQuestionnaire>, IAuditQuestionnaireRepository
    {
        private readonly DNCProjectAuditContext _context;

        public AuditQuestionnaireRepository(DNCProjectAuditContext context) : base(context) 
        {
            _context = context;
        }

        public Task<PagedResult<AuditQuestionnaire>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuditQuestionnaire>> GetAllAuditQuestionnaires()
        {
            return await _context.AuditQuestionnaires.ToListAsync();
        }

        public async Task<IEnumerable<AuditQuestionnaire>> GetAuditQuestionnairesByRegion(Region region)
        {
            return await _context.AuditQuestionnaires.Where(a => a.Region == region).ToListAsync();
        }

        public AuditQuestionnaire GetByTitle(string title)
        {
            return _context.AuditQuestionnaires.FirstOrDefault(a => a.Name == title)!;
        }
    }
}
