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

        public async Task<IEnumerable<SelectListQuestion>> GetAllSelectListQuestions()
        {
            return await _context.SelectListQuestions.ToListAsync();
        }

        public async Task<IEnumerable<SelectListQuestion>> GetAllSelectListQuestionsByAudtiQuestionnaireId(int id)
        {
            return await _context.SelectListQuestions.Where(s => s.QuestionAuditQuestionnaireId == id && s.Id > 0).ToListAsync();
        }

        public async Task<SelectListQuestion> GetByQuestionText(string questionText)
        {
            var question = await _context.SelectListQuestions.FirstOrDefaultAsync(s => s.QuestionText == questionText);
            return question!;
        }

        public async Task<SelectListQuestion> GetQuestionByQuestionnaireIdAndQuestionText(int questionnaireId, string questionTex)
        {
            var question = await _context.SelectListQuestions.FirstOrDefaultAsync(s => s.QuestionAuditQuestionnaireId == questionnaireId && s.QuestionText == questionTex);
            return question!;
        }

        public SelectListQuestion GetQuestionByQuestionText(string questionText)
        {
            return _context.SelectListQuestions.Where(s => s.QuestionText == questionText).FirstOrDefault()!;
        }

        public async Task<IEnumerable<SelectListQuestion>> GetSelectListQuestionsByAudtiQuestionnaireIdAndByDisplayPriorityIndication(int id)
        {
            return await _context.SelectListQuestions.Where(s => s.QuestionAuditQuestionnaireId == id && s.Id > 0 && s.IsDisplay == true).OrderByDescending(s => s.PriorityIndication).ToListAsync();
        }

        public async Task<IEnumerable<SelectListQuestion>> GetSelectListQuestionsByDisplayPriorityIndication()
        {
            return await _context.SelectListQuestions.Where(s => s.Id > 0 && s.IsDisplay == true).OrderByDescending(s => s.PriorityIndication).ToListAsync();
        }
    }
}
