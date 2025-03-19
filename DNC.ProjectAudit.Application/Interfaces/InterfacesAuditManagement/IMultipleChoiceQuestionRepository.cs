using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement
{
    public interface IMultipleChoiceQuestionRepository : IGenericRepository<MultipleChoiceQuestion>
    {
        Task<IEnumerable<MultipleChoiceQuestion>> GetAllMultipleChoiceQuestions();
        Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireId(int id);
        Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByDisplayPriorityIndication();
        Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndication(int id);
        MultipleChoiceQuestion GetByQuestionText(string questionText);
        Task<MultipleChoiceQuestion> GetQuestionByQuestionText(string questionText);
        Task<MultipleChoiceQuestion> GetQuestionByQuestionnaireIdAndQuestionText(int questionnaireId, string questionText);
    }
}
