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
        Task<IEnumerable<SelectListQuestion>> GetAllSelectListQuestions();
        Task<IEnumerable<SelectListQuestion>> GetSelectListQuestionsByDisplayPriorityIndication();
        Task<IEnumerable<SelectListQuestion>> GetAllSelectListQuestionsByAudtiQuestionnaireId(int id);
        Task<IEnumerable<SelectListQuestion>> GetSelectListQuestionsByAudtiQuestionnaireIdAndByDisplayPriorityIndication(int id);
        SelectListQuestion GetQuestionByQuestionText(string questionText);
        Task<SelectListQuestion> GetByQuestionText(string questionText);
        Task<SelectListQuestion> GetQuestionByQuestionnaireIdAndQuestionText(int questionnaireId, string questionTex);
    }
}
