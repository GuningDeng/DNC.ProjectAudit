using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace DNC.ProjectAudit.EmployeeClient.Services
{
    public class AuditQuestionnaireService
    {
        private readonly HttpClient httpClient;

        public AuditQuestionnaireService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<AuditQuestionnaireDTO>> GetAuditQuestionnaireDTOs()
        {
            // 定义常量以避免硬编码 URL
            const string apiEndpoint = "AuditQuestionnaires/Quick";
            

            try
            {
                // 发起 HTTP 请求并解析 JSON
                var questionnaires = await httpClient.GetFromJsonAsync<List<AuditQuestionnaireDTO>>(apiEndpoint);

                // 检查返回结果是否为 null
                if (questionnaires == null)
                {
                    // 根据业务需求决定如何处理 null 情况
                    // 此处可以选择抛出自定义异常或返回空列表
                    throw new InvalidOperationException("The API returned a null response.");
                }

                return questionnaires;
            }
            catch (HttpRequestException ex)
            {
                // 捕获网络请求相关异常
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
            catch (JsonException ex)
            {
                // 捕获 JSON 解析相关异常
                Console.Error.WriteLine($"JSON parsing failed: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
            catch (Exception ex)
            {
                // 捕获其他未知异常
                Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
        }

        public async Task<List<AuditQuestionnaireDTO>> GetAuditQuestionnaireDTOsWithEndingText(string endingText)
        {
            const string apiEndpoint = "AuditQuestionnaires/Quick";
            try
            {
                var questionnaires = await httpClient.GetFromJsonAsync<List<AuditQuestionnaireDTO>>(apiEndpoint);
                if (questionnaires == null)
                {
                    throw new InvalidOperationException("The API returned a null response.");
                }
                
                var questionnairesWithSpecificEndingText = questionnaires!.Where(q => q.Name!.EndsWith(endingText)).ToList();
                if (questionnairesWithSpecificEndingText == null)
                {
                    throw new InvalidOperationException("The API returned a null response.");
                }
                
                return questionnairesWithSpecificEndingText;
            }
            catch (HttpRequestException ex)
            {
                // 捕获网络请求相关异常
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
            catch (JsonException ex)
            {
                // 捕获 JSON 解析相关异常
                Console.Error.WriteLine($"JSON parsing failed: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
            catch (Exception ex)
            {
                // 捕获其他未知异常
                Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw; // 重新抛出异常以便调用方处理
            }
        }

        public async Task<AuditQuestionnaireDTO> GetAuditQuestionnaireDTO(int id)
        {
            try
            {
                // 定义常量以避免硬编码
                const string apiEndpoint = "AuditQuestionnaires/{0}/Quick";

                // 构造完整的 API URL
                string url = string.Format(apiEndpoint, id);

                // 发送 HTTP 请求并获取结果
                AuditQuestionnaireDTO? questionnaire = await httpClient.GetFromJsonAsync<AuditQuestionnaireDTO>(url);

                // 检查返回值是否为 null
                if (questionnaire == null)
                {
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }

                return questionnaire;
            }
            catch (HttpRequestException ex)
            {
                // 捕获 HTTP 请求相关的异常
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                // 捕获 JSON 解析相关的异常
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {
                // 捕获其他未知异常
                Console.Error.WriteLine($"An unexpected error occurred while retrieving questionnaire with ID {id}: {ex.Message}");
                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireDetailDTO(int id)
        {
            try
            {
                // 定义常量以避免硬编码
                const string apiEndpoint = "AuditQuestionnaires/{0}";

                // 构造完整的 API URL
                string url = string.Format(apiEndpoint, id);

                // 发送 HTTP 请求并获取结果
                AuditQuestionnaireDetailDTO? questionnaire = await httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>(url);

                // 检查返回值是否为 null
                if (questionnaire == null)
                {
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }

                return questionnaire;
            }
            catch (HttpRequestException ex)
            {
                // 捕获 HTTP 请求相关的异常
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                // 捕获 JSON 解析相关的异常
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {
                // 捕获其他未知异常
                Console.Error.WriteLine($"An unexpected error occurred while retrieving questionnaire with ID {id}: {ex.Message}");
                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireDTOByName(string name)
        {
            try
            {
                const string apiEndpoint = "AuditQuestionnaires/{0}/ByName";

                string url = string.Format(apiEndpoint, name);
                var questionnaire = await httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>(url);
                return questionnaire!;
            }
            catch (Exception ex)
            {
                // 捕获其他未知异常
                Console.Error.WriteLine($"An unexpected error occurred while retrieving questionnaire with name {name}: {ex.Message}");
                throw new Exception($"Unexpected error retrieving questionnaire with name {name}", ex);
            }

        }

        public async Task<HttpResponseMessage> UpdateAuditQuestionnaire(int id, AuditQuestionnaireDetailDTO updatedAuditQuestionnaire)
        {
            try
            {
                const string apiEndpoint = "AuditQuestionnaires/{0}";
                string url = string.Format(apiEndpoint, id);

                var response = await httpClient.PutAsJsonAsync(url, updatedAuditQuestionnaire);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }


        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOsByQuestionnaireId(int id)
        {
            try
            {
                const string apiEndpoint = "AuditQuestionnaires/{0}/MultipleChoiceQuestionsByIsDisplayPriority";

                string url = string.Format(apiEndpoint, id);

                var choices = await httpClient.GetFromJsonAsync<List<MultipleChoiceQuestionDTO>>(url);
                if (choices == null)
                {
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }
                return choices!;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

        public async Task<HttpResponseMessage> UpdateMultipleChoiceQuestion(int id, MultipleChoiceQuestionDTO updatedMultipleChoiceQuestion)
        {
            try
            {
                const string apiEndpoint = "MultipleChoiceQuestions/{0}";
                string url = string.Format(apiEndpoint, id);

                var response = await httpClient.PutAsJsonAsync(url, updatedMultipleChoiceQuestion);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }

        }
        

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOsByQuestionnaireId(int id)
        {
            try
            {
                const string apiEndpoint = "AuditQuestionnaires/{0}/OpenQuestionsByAuditQuestionnaireId";

                string url = string.Format(apiEndpoint, id);

                var questions = await httpClient.GetFromJsonAsync<List<OpenQuestionDTO>>(url);
                return questions == null ? throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}") : questions!;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }

        }

        public async Task<HttpResponseMessage> UpdateOpenQuestionDTO(int id, OpenQuestionDTO updatedOpenQuestion)
        {
            try
            {
                const string apiEndpoint = "OpenQuestions/{0}";
                string url = string.Format(apiEndpoint, id);
                return await httpClient.PutAsJsonAsync(url, updatedOpenQuestion);
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOsByQuestionnaireId(int id)
        {
            try
            {
                const string apiEndpoint = "AuditQuestionnaires/{0}/SelectListQuestionsByAuditQuestionnaireId";

                string url = string.Format(apiEndpoint, id);
                var questions = await httpClient.GetFromJsonAsync<List<SelectListQuestionDTO>>(url);
                return questions == null ? throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}") : questions!;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

        public async Task<HttpResponseMessage> UpdateSelectListQuestionDTO(int id, SelectListQuestionDTO updatedSelectListQuestion)
        {
            try
            {
                const string apiEndpoint = "SelectListQuestions/{0}";
                string url = string.Format(apiEndpoint, id);
                return await httpClient.PutAsJsonAsync(url, updatedSelectListQuestion);
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }

    }
}
