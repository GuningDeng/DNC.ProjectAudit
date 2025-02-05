using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.AuditClient.Services
{
    public class AuditQuestionnaireService
    {
        private readonly HttpClient _httpClient;

        public AuditQuestionnaireService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<AuditQuestionnaireDetailDTO>> GetAuditQuestionnaireDetailDTOs()
        {
            return await _httpClient.GetFromJsonAsync<List<AuditQuestionnaireDetailDTO>>("AuditQuestionnaires");
        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaire(int id)
        {
            return await _httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>($"AuditQuestionnaires/{id}");
        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOs()
        {
            return await _httpClient.GetFromJsonAsync<List<MultipleChoiceQuestionDTO>>($"MultipleChoiceQuestions");
        }

        public async Task<MultipleChoiceQuestionDTO> GetMultipleChoiceQuestionDTO(int id)
        {
            return await _httpClient.GetFromJsonAsync<MultipleChoiceQuestionDTO>($"MultipleChoiceQuestions/{id}");
        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOsByAuditQuestionnaireId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<MultipleChoiceQuestionDTO>>($"AuditQuestionnaires/{id}/MultipleChoiceQuestions");
        }

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOs()
        {
            return await _httpClient.GetFromJsonAsync<List<OpenQuestionDTO>>("OpenQuestions");
        }

        public async Task<OpenQuestionDTO> GetOpenQuestion(int id)
        {
            return await _httpClient.GetFromJsonAsync<OpenQuestionDTO>($"OpenQuestions/{id}");
        }

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOsByAuditQuestionnaireId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<OpenQuestionDTO>>($"AuditQuestionnaires/{id}/OpenQuestionsByAuditQuestionnaireId");
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOs()
        {
            return await _httpClient.GetFromJsonAsync<List<SelectListQuestionDTO>>("SelectListQuestions");
        }

        public async Task<SelectListQuestionDTO> GetSelectListQuestionDTO(int id)
        {
            return await _httpClient.GetFromJsonAsync<SelectListQuestionDTO>($"SelectListQuestions/{id}");
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOsByAuditQuestionnaireId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<SelectListQuestionDTO>>($"AuditQuestionnaires/{id}/SelectListQuestionsByAuditQuestionnaireId");
        }

    }
}
