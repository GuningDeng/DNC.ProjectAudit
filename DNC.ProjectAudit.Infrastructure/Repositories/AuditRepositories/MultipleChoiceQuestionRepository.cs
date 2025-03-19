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
        //GetAllMultipleChoiceQuestions
        public async Task<IEnumerable<MultipleChoiceQuestion>> GetAllMultipleChoiceQuestions()
        {
            return await _context.MultipleChoiceQuestions.ToListAsync();
        }
        //GetByQuestionText
        public MultipleChoiceQuestion GetByQuestionText(string questionText)
        {
            return _context.MultipleChoiceQuestions.Where(m => m.QuestionText == questionText).FirstOrDefault()!;
        }

        public async Task<MultipleChoiceQuestion> GetQuestionByQuestionnaireIdAndQuestionText(int questionnaireId, string questionText)
        {
            var question = await _context.MultipleChoiceQuestions.Where(m => m.QuestionAuditQuestionnaireId == questionnaireId && m.QuestionText == questionText).FirstOrDefaultAsync();
            return question!;
        }

        public async Task<MultipleChoiceQuestion> GetQuestionByQuestionText(string questionText)
        {
            var question = await _context.MultipleChoiceQuestions.Where(m => m.QuestionText == questionText).FirstOrDefaultAsync();
            return question!;
        }

        //GetQuestionsByAudtiQuestionnaireId
        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireId(int id)
        {
            return await _context.MultipleChoiceQuestions.Where(m => m.QuestionAuditQuestionnaireId == id).ToListAsync();
        }
        //GetQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndication
        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndication(int id)
        {
            return await _context.MultipleChoiceQuestions.Where(m => m.QuestionAuditQuestionnaireId == id && m.Id > 0 && m.IsDisplay == true).OrderByDescending(m => m.PriorityIndication).ToListAsync();
        }
        //GetQuestionsByDisplayPriorityIndication
        public async Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByDisplayPriorityIndication()
        {
            return await _context.MultipleChoiceQuestions.OrderByDescending(m => m.PriorityIndication).ToListAsync();
        }
    }
    
}
