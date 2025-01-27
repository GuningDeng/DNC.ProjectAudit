using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement
{
    public interface ISelectListQuestionRepository : IGenericRepository<SelectListQuestion>
    {
        Task<IEnumerable<SelectListQuestion>> GetAllOpenQuestions();
        Task<IEnumerable<SelectListQuestion>> GetAllOpenQuestionsByDisplyPriorityIndication();
        Task<IEnumerable<SelectListQuestion>> GetQuestionsByAudtiQuestionnaireId(int id);
        Task<IEnumerable<SelectListQuestion>> GetOpenQuestionsByAudtiQuestionnaireIdAndByDisplyPriorityIndication(int id);
        SelectListQuestion GetQuestionByQuestionText(string questionText);
    }
}
