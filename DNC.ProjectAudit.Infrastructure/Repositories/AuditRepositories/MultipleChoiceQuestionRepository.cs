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
    public class MultipleChoiceQuestionRepository : GenericRepository<MultipleChoiceQuestion>, IMultipleChoiceQuestionRepository
    {
        private readonly DNCProjectAuditContext _context;

        public MultipleChoiceQuestionRepository(DNCProjectAuditContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<IEnumerable<MultipleChoiceQuestion>> GetAllMultipleChoiceQuestions()
        {
            return await _context.MultipleChoiceQuestions.ToListAsync();
        }

        public MultipleChoiceQuestion GetByQuestionText(string questionText)
        {
            return _context.MultipleChoiceQuestions.Where(m => m.QuestionText == questionText).FirstOrDefault()!;
        }

        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireId(int id)
        {
            return await _context.MultipleChoiceQuestions.Where(m => m.QuestionAuditQuestionnaireId == id).ToListAsync();
        }

        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndication(int id)
        {
            return await _context.MultipleChoiceQuestions.Where(m => m.QuestionAuditQuestionnaireId == id && m.Id > 0 && m.IsDisplay == true).OrderByDescending(m => m.PriorityIndication).ToListAsync();
        }

        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByDisplyPriorityIndication()
        {
            return await _context.MultipleChoiceQuestions.OrderByDescending(m => m.PriorityIndication).ToListAsync();
        }
    }
    
}
