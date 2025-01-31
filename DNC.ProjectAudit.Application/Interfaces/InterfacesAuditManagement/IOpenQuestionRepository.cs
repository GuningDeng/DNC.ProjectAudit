using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement
{
    public interface IOpenQuestionRepository : IGenericRepository<OpenQuestion>
    {
        Task<IEnumerable<OpenQuestion>> GetAllOpenQuestions();
        Task<IEnumerable<OpenQuestion>> GetAllOpenQuestionsByDisplayPriorityIndication();
        Task<IEnumerable<OpenQuestion>> GetQuestionsByAudtiQuestionnaireId(int id);
        Task<IEnumerable<OpenQuestion>> GetOpenQuestionsByAudtiQuestionnaireIdAndByDisplayPriorityIndication(int id);
        OpenQuestion GetQuestionByQuestionText(string questionText);
    }
}
