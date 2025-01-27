using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using DNC.ProjectAudit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Repositories.AuditRepositories
{
    public class SelectListQuestionRepository : GenericRepository<SelectListQuestion>, ISelectListQuestionRepository
    {
        private readonly DNCProjectAuditContext _context;

        public SelectListQuestionRepository(DNCProjectAuditContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListQuestion>> GetAllOpenQuestions()
        {
            return await _context.SelectListQuestions.ToListAsync();
        }

        public Task<IEnumerable<SelectListQuestion>> GetAllOpenQuestionsByDisplyPriorityIndication()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListQuestion>> GetOpenQuestionsByAudtiQuestionnaireIdAndByDisplyPriorityIndication(int id)
        {
            throw new NotImplementedException();
        }

        public SelectListQuestion GetQuestionByQuestionText(string questionText)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListQuestion>> GetQuestionsByAudtiQuestionnaireId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
