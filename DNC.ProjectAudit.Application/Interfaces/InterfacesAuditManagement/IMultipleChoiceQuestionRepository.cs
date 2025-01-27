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
        Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByDisplyPriorityIndication();
        Task<IEnumerable<MultipleChoiceQuestion>> GetQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndication(int id);
        MultipleChoiceQuestion GetByQuestionText(string questionText);
    }
}
