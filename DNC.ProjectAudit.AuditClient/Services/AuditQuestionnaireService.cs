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
            var questionnaires = await _httpClient.GetFromJsonAsync<List<AuditQuestionnaireDetailDTO>>("AuditQuestionnaires");
            return questionnaires!;
        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaire(int id)
        {
            var existing = await _httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>($"AuditQuestionnaires/{id}");
            return existing!;
        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireByName(string name)
        {
            var existing = await _httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>($"AuditQuestionnaires/{name}/ByName");
            //if (existing != null) throw new KeyNotFoundException("questionnaire exists already");
            return existing!;
        }

        public async Task<HttpResponseMessage> PostAuditQuestionnaire(AuditQuestionnaireDetailDTO auditQuestionnaire)
        {
            var response = await _httpClient.PostAsJsonAsync("AuditQuestionnaires", auditQuestionnaire);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatedQuestionnaire(int id, AuditQuestionnaireDetailDTO auditQuestionnaire)
        {
            var response = await _httpClient.PutAsJsonAsync($"AuditQuestionnaires/{id}", auditQuestionnaire);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteQuestionnaire(int id)
        {
            var response = await _httpClient.DeleteAsync($"AuditQuestionnaires/{id}");
            return response;
        }


        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOs()
        {
            var questions = await _httpClient.GetFromJsonAsync<List<MultipleChoiceQuestionDTO>>($"MultipleChoiceQuestions");
            return questions!;
        }

        public async Task<MultipleChoiceQuestionDTO> GetMultipleChoiceQuestionDTO(int id)
        {
            var question = await _httpClient.GetFromJsonAsync<MultipleChoiceQuestionDTO>($"MultipleChoiceQuestions/{id}");
            return question!;
        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOsByAuditQuestionnaireId(int id)
        {
            var questions = await _httpClient.GetFromJsonAsync<List<MultipleChoiceQuestionDTO>>($"AuditQuestionnaires/{id}/MultipleChoiceQuestions");
            return questions!;
        }

        public async Task<HttpResponseMessage> ExistMultipleChoiceQuestionByQuestionText(string text)
        {
            var response = await _httpClient.GetAsync($"MultipleChoiceQuestions/{text}/MultipleChoiceByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> ExistMultipleChoiceQuestionByQuestionnnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            var response = await _httpClient.GetAsync($"MultipleChoiceQuestions/{questionnaireId}/{text}/MultipleChoiceByQuestionnaireIdAndByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> PostMultipleChoiceQuestion(MultipleChoiceQuestionDTO multipleChoiceQuestionDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("MultipleChoiceQuestions", multipleChoiceQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateMultipleChoiceQuestion(int id, MultipleChoiceQuestionDTO updateMultipleChoiceQuestionDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"MultipleChoiceQuestions/{id}", updateMultipleChoiceQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteMultipleChoiceQuestion(int id)
        {
            var response = await _httpClient.DeleteAsync($"MultipleChoiceQuestions/{id}");
            return response;
        }

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOs()
        {
            var questions = await _httpClient.GetFromJsonAsync<List<OpenQuestionDTO>>("OpenQuestions");
            return questions!;
        }

        public async Task<OpenQuestionDTO> GetOpenQuestion(int id)
        {
            var question = await _httpClient.GetFromJsonAsync<OpenQuestionDTO>($"OpenQuestions/{id}");
            return question!;
        }

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOsByAuditQuestionnaireId(int id)
        {
            var questions = await _httpClient.GetFromJsonAsync<List<OpenQuestionDTO>>($"AuditQuestionnaires/{id}/OpenQuestionsByAuditQuestionnaireId");
            return questions!;
        }

        public async Task<HttpResponseMessage> ExistOpenQuestionByQuestionText(string text)
        {
            var response = await _httpClient.GetAsync($"OpenQuestions/{text}/ByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> ExistOpenQuestionByQuestionnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            var response = await _httpClient.GetAsync($"OpenQuestions/{questionnaireId}/{text}/OpenQuestionByQuestionnaireIdAndByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> PostOpenQuestion(OpenQuestionDTO openQuestionDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("OpenQuestions", openQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateOpenQuestion(int id, OpenQuestionDTO updateOpenQuestionDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"OpenQuestions/{id}", updateOpenQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteOpenQuestion(int id)
        {
            var response = await _httpClient.DeleteAsync($"OpenQuestions/{id}");
            return response;
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOs()
        {
            var questions = await _httpClient.GetFromJsonAsync<List<SelectListQuestionDTO>>("SelectListQuestions");
            return questions!;
        }

        public async Task<SelectListQuestionDTO> GetSelectListQuestionDTO(int id)
        {
            var question = await _httpClient.GetFromJsonAsync<SelectListQuestionDTO>($"SelectListQuestions/{id}");
            return question!;
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOsByAuditQuestionnaireId(int id)
        {
            var questions = await _httpClient.GetFromJsonAsync<List<SelectListQuestionDTO>>($"AuditQuestionnaires/{id}/SelectListQuestionsByAuditQuestionnaireId");
            return questions!;
        }

        public async Task<HttpResponseMessage> ExistSelectListQuestionByQuestionText(string text)
        {
            var response = await _httpClient.GetAsync($"SelectListQuestions/{text}/ByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> ExistSelectListByQuestionnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            var response = await _httpClient.GetAsync($"SelectListQuestions/{questionnaireId}/{text}/OpenQuestionByQuestionnaireIdAndByQuestionText");
            return response;
        }

        public async Task<HttpResponseMessage> PostSelectListQuestion(SelectListQuestionDTO selectListQuestionDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("SelectListQuestions", selectListQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSelectListQuestion(int id, SelectListQuestionDTO updateSelectListQuestionDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"SelectListQuestions/{id}", updateSelectListQuestionDTO);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteSelectListQuestion(int id)
        {
            var response = await _httpClient.DeleteAsync($"SelectListQuestions/{id}");
            return response;
        }
    }
}
