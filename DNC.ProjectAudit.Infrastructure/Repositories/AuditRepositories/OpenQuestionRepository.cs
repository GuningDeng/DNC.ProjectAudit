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
    public class OpenQuestionRepository : GenericRepository<OpenQuestion>, IOpenQuestionRepository
    {
        private readonly DNCProjectAuditContext _context;

        public OpenQuestionRepository(DNCProjectAuditContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpenQuestion>> GetAllOpenQuestions()
        {
            return await _context.OpenQuestions.ToListAsync();
        }

        public async Task<IEnumerable<OpenQuestion>> GetAllOpenQuestionsByDisplayPriorityIndication()
        {
            return await _context.OpenQuestions.Where(o => o.IsDisplay == true && o.Id > 0).OrderByDescending(o => o.PriorityIndication).ToListAsync();
        }

        public async Task<IEnumerable<OpenQuestion>> GetOpenQuestionsByAudtiQuestionnaireIdAndByDisplayPriorityIndication(int id)
        {
            return await _context.OpenQuestions.Where(o => o.Id > 0 && o.IsDisplay == true).OrderByDescending(o => o.PriorityIndication).ToListAsync();
        }

        public OpenQuestion GetQuestionByQuestionText(string questionText)
        {
            return _context.OpenQuestions.Where(o => o.QuestionText == questionText).FirstOrDefault()!;
        }

        public async Task<IEnumerable<OpenQuestion>> GetQuestionsByAudtiQuestionnaireId(int id)
        {
            return await _context.OpenQuestions.Where(o => o.QuestionAuditQuestionnaireId == id).ToListAsync();
        }
    }
}
