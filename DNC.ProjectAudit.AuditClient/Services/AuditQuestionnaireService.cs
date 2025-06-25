using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            try
            {
                var response = await _httpClient.GetAsync("AuditQuestionnaires");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<AuditQuestionnaireDetailDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                    
                }
                else
                {
                    Console.Error.WriteLine("The API returned a null response.");
                    throw new InvalidOperationException("The API returned a null response.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine($"Error retrieving questionnaires: {ex.Message}");
                throw;
            }
        }
                

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaire(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}";
            //string url = string.Format(apiEndpoint, id);
            string url = new Uri(string.Format(apiEndpoint, id), UriKind.Relative).ToString();
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<AuditQuestionnaireDetailDTO>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving questionnaire with ID {id}", new Exception($"HTTP request failed with status code: {response.StatusCode}"));
                }

            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine($"Error retrieving questionnaire with ID {id}: {ex.Message}");
                throw;
            }

        }

        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireByName(string name)
        {
            //var existing = await _httpClient.GetFromJsonAsync<AuditQuestionnaireDetailDTO>($"AuditQuestionnaires/{name}/ByName");
            //if (existing != null) throw new KeyNotFoundException("questionnaire exists already");
            //return existing!;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Error.WriteLine("Invalid name");
                return null!;
            }
            //string encodedText = Uri.EscapeDataString(text);
            //string url = $"SelectListQuestions/{encodedText}/ByQuestionText";
            //const string apiEndpoint = "AuditQuestionnaires/{0}/ByName";
            string encodedText = Uri.EscapeDataString(name);
            string url = $"AuditQuestionnaires/{encodedText}/ByName";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<AuditQuestionnaireDetailDTO>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {name}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for name {name}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine($"Error retrieving questionnaire with name {name}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> PostAuditQuestionnaire(AuditQuestionnaireDetailDTO auditQuestionnaire)
        {
            if (auditQuestionnaire == null)
            {
                throw new ArgumentNullException(nameof(auditQuestionnaire), "Audit questionnaire can not be empty");
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("AuditQuestionnaires", auditQuestionnaire);

                // Optional: 
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdatedQuestionnaire(int id, AuditQuestionnaireDetailDTO auditQuestionnaire)
        {
            if (id <= 0)
            {
                throw  new ArgumentException("Invalid id");
            }
            if (auditQuestionnaire == null)
            {
                throw new ArgumentException("Audit questionnaire can not be empty");
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, auditQuestionnaire);
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error updating questionnaire with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteQuestionnaire(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id");
            }

            const string apiEndpoint = "AuditQuestionnaires/{0}";
            string url = string.Format(apiEndpoint, id);

            try
            {
                var response = await _httpClient.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error deleting questionnaire with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }

        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOs()
        {
            const string apiEndpoint = "MultipleChoiceQuestions";
            try
            {
                var response = await _httpClient.GetAsync(apiEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<MultipleChoiceQuestionDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving multiple choice", new HttpRequestException());
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving multiple chioce: {ex.Message}");
                throw;
            }

        }

        public async Task<MultipleChoiceQuestionDTO> GetMultipleChoiceQuestionDTO(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "MultipleChoiceQuestions/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<MultipleChoiceQuestionDTO>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestionDTOsByAuditQuestionnaireId(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}/MultipleChoiceQuestions";
            string url = new Uri(string.Format(apiEndpoint, id),  UriKind.Relative).ToString();
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                { 
                    var content = await response.Content.ReadFromJsonAsync<List<MultipleChoiceQuestionDTO>>();
                    if (content == null) 
                    { 
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch  (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> ExistMultipleChoiceQuestionByQuestionText(string text)
        {
            var response = await _httpClient.GetAsync($"MultipleChoiceQuestions/{text}/MultipleChoiceByQuestionText");
            return response;
        }

        public async Task<bool> ExistMultipleChoiceQuestionByQuestionnnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            if (questionnaireId <= 0)
            {
                Console.Error.WriteLine("Invalid questionnaireId");
                return false;
            }
            if (string.IsNullOrEmpty(text))
            {
                Console.Error.WriteLine("Invalid text");
                return false;
            }
            string encodedText = Uri.EscapeDataString(text);
            string url = $"AuditQuestionnaires/{questionnaireId}/{encodedText}/MultipleChoiceByQuestionnaireIdAndByQuestionText";
            try
            {
                var response = await _httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {questionnaireId}: {ex.Message}");
                return false;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {questionnaireId}: {ex.Message}");
                return  false;
            }
            
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
            try
            {
                var response = await _httpClient.GetAsync("OpenQuestions");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<OpenQuestionDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question", new HttpRequestException(response.ReasonPhrase));
                }
            } catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            } catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question: {ex.Message}");
                throw;
            }
        }

        public async Task<OpenQuestionDTO> GetOpenQuestion(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const  string apiEndpoint = "OpenQuestions/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<OpenQuestionDTO>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            } 
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }             
            catch (Exception ex) when  (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<OpenQuestionDTO>> GetOpenQuestionDTOsByAuditQuestionnaireId(int id)
        {
            if  (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}/OpenQuestionsByAuditQuestionnaireId";
            string url = new Uri(string.Format(apiEndpoint, id), UriKind.Relative).ToString();
            try
            { 
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<OpenQuestionDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine($"Error retrieving questionnaire with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> ExistOpenQuestionByQuestionText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.Error.WriteLine("Invalid text");
                return null!;
            }
            string encodedText = Uri.EscapeDataString(text);
            string url = $"OpenQuestions/{encodedText}/ByQuestionText";
            try
            {
                var response = await _httpClient.GetAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for text {text}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with text {text}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExistOpenQuestionByQuestionnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            if (questionnaireId <= 0 || string.IsNullOrWhiteSpace(text))
            {
                Console.Error.WriteLine("Invalid questionnaireId or text");
                return false;
            }
            string encodedText = Uri.EscapeDataString(text);
            string url = $"OpenQuestions/{questionnaireId}/{encodedText}/OpenQuestionByQuestionnaireIdAndByQuestionText";
            try
            {
                var response = await _httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for questionnaireId {questionnaireId} and text {text}: {ex.Message}");
                return false;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with questionnaireId {questionnaireId} and text {text}: {ex.Message}");
                return  false;
            }
        }

        public async Task<HttpResponseMessage> PostOpenQuestion(OpenQuestionDTO openQuestionDTO)
        {
            if (openQuestionDTO == null)
            {
                Console.Error.WriteLine("Invalid openQuestionDTO");
                return null!;
            }
            const  string apiEndpoint = "OpenQuestions";
            try
            {
                var response = await _httpClient.PostAsJsonAsync(apiEndpoint, openQuestionDTO);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for OpenQuestionDTO: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error posting OpenQuestionDTO: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdateOpenQuestion(int id, OpenQuestionDTO updateOpenQuestionDTO)
        {
            if (id <= 0 || updateOpenQuestionDTO == null)
            {
                Console.Error.WriteLine("Invalid id or updateOpenQuestionDTO");
                throw new ArgumentException("Id and open question cannot be null.", nameof(OpenQuestionDTO));
            }
            const string apiEndpoint = "OpenQuestions/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, updateOpenQuestionDTO);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error updating question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteOpenQuestion(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                throw new ArgumentException("Id cannot be null.", nameof(id));
            }
            const string apiEndpoint = "OpenQuestions/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error deleting question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOs()
        {
            const string apiEndpoint = "SelectListQuestions";
            try
            {
                var response = await _httpClient.GetAsync(apiEndpoint);
                if  (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<SelectListQuestionDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving questions: {ex.Message}");
                throw;
            }
        }

        public async Task<SelectListQuestionDTO> GetSelectListQuestionDTO(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "SelectListQuestions/{0}";
            string url = string.Format(apiEndpoint, id);
            try
            {
                var response = await _httpClient.GetAsync(url);
                if  (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<SelectListQuestionDTO>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw   new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOsByAuditQuestionnaireId(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                return null!;
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}/SelectListQuestionsByAuditQuestionnaireId";
            
            string url = new Uri(string.Format(apiEndpoint, id), UriKind.Relative).ToString();

            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                { 
                    var content = await response.Content.ReadFromJsonAsync<List<SelectListQuestionDTO>>();
                    if (content == null)
                    {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving question with ID {id}", new HttpRequestException(response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> ExistSelectListQuestionByQuestionText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.Error.WriteLine("Invalid text");
                throw new ArgumentException("Text cannot be null or whitespace.", nameof(text));
            }
            string encodedText = Uri.EscapeDataString(text);
            string url = $"SelectListQuestions/{encodedText}/ByQuestionText";
            try
            {
                var response = await _httpClient.GetAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for text {text}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with text {text}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> ExistSelectListByQuestionnaireIdAndByQuestionText(int questionnaireId, string text)
        {
            if (questionnaireId <= 0)
            {
                Console.Error.WriteLine("Invalid questionnaireId");
                throw new ArgumentException("QuestionnaireId cannot be less than or equal to zero.", nameof(questionnaireId));
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.Error.WriteLine("Invalid text");
                throw new ArgumentException("Text cannot be null or whitespace.", nameof(text));
            }

            string encodedText = Uri.EscapeDataString(text);
            string url = $"SelectListQuestions/{questionnaireId}/{encodedText}/OpenQuestionByQuestionnaireIdAndByQuestionText";
            try
            {
                var response = await _httpClient.GetAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for questionnaireId {questionnaireId} and text {text}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with questionnaireId {questionnaireId} and text {text}: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> PostSelectListQuestion(SelectListQuestionDTO selectListQuestionDTO)
        {
            if (selectListQuestionDTO == null)
            {
                Console.Error.WriteLine("Invalid selectListQuestionDTO");
                throw new ArgumentNullException(nameof(selectListQuestionDTO), "selectListQuestionDTO cannot be null.");
            }
            try
            {
                var response = await _httpClient.PostAsJsonAsync("SelectListQuestions", selectListQuestionDTO);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for selectListQuestionDTO: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error posting selectListQuestionDTO: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdateSelectListQuestion(int id, SelectListQuestionDTO updateSelectListQuestionDTO)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                throw new ArgumentException("Id cannot be less than or equal to zero.", nameof(id));
            }
            if (updateSelectListQuestionDTO == null)
            {
                Console.Error.WriteLine("Invalid updateSelectListQuestionDTO");
                throw new ArgumentNullException(nameof(updateSelectListQuestionDTO), "updateSelectListQuestionDTO cannot be null.");
            }
            string url = $"SelectListQuestions/{id}";
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, updateSelectListQuestionDTO);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }

        }

        public async Task<HttpResponseMessage> DeleteSelectListQuestion(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid id");
                throw new ArgumentException("Id cannot be less than or equal to zero.", nameof(id));
            }
            string url = $"SelectListQuestions/{id}";
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving question with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
