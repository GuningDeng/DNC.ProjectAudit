using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;

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
            // Define constants to avoid hard-coding URLs
            const string apiEndpoint = "AuditQuestionnaires/Quick";
            
            try
            {
                var response = await httpClient.GetAsync(apiEndpoint);
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    return new List<AuditQuestionnaireDTO>(0); // Return an empty list if the request fails.

                }
                var content = await response.Content.ReadFromJsonAsync<List<AuditQuestionnaireDTO>>();
                if (content == null )
                {
                    Console.WriteLine("The API returned a null response.");
                    return new List<AuditQuestionnaireDTO>(0);

                }
                return content;                   

            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"Network error during HTTP request: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching audit questionnaire data.", ex);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while fetching audit questionnaire data.", ex);
            }
        }
                
        public async Task<List<AuditQuestionnaireDTO>> GetAuditQuestionnaireDTOsWithEndingText(string endingText)
        {
            const string apiEndpoint = "AuditQuestionnaires/Quick";
            if (string.IsNullOrEmpty(endingText))
            {
                throw new ArgumentException("Ending text cannot be null or empty.", nameof(endingText));
            }

            try
            {
                var response = await httpClient.GetAsync(apiEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<List<AuditQuestionnaireDTO>>() ?? throw new InvalidOperationException("The API returned a null response.");

                    // Handle null Name, and filter data
                    var questionnairesWithSpecificEndingText = content
                        .Where(q => q.Name != null && q.Name.EndsWith(endingText, StringComparison.Ordinal))
                        .ToList();

                    return questionnairesWithSpecificEndingText;
                }
                else
                {
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON parsing failed: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }

            return new List<AuditQuestionnaireDTO>(0); // Defualt return empty list if no matching questionnaires found.
        }

        public async Task<AuditQuestionnaireDTO> GetAuditQuestionnaireDTO(int id)
        {
            if (id <= 0)
            {
                Console.Error.WriteLine("Invalid ID.");
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            }
            // Define constant to avoid hardcoding
            const string apiEndpoint = "AuditQuestionnaires/{0}/Quick";

            // Build the complete API URL
            string url = string.Format(apiEndpoint, id);
            try
            {
                // Send HTTP request and get result
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as JSON
                    var content = await response.Content.ReadFromJsonAsync<AuditQuestionnaireDTO>();
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
                    throw new Exception($"HTTP request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Caputch HTTP request related exceptions
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with ID {id}", ex);
            }
            catch (JsonException ex)
            {
                // Capuch JSON parsing related exceptions
                Console.Error.WriteLine($"JSON parsing failed for ID {id}: {ex.Message}");
                throw new Exception($"Error parsing JSON for questionnaire with ID {id}", ex);
            }
            catch (Exception ex)
            {
                // Captch other unexpected exceptions
                Console.Error.WriteLine($"An unexpected error occurred while retrieving questionnaire with ID {id}: {ex.Message}");
                throw new Exception($"Unexpected error retrieving questionnaire with ID {id}", ex);
            }
        }
                
        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireDetailDTO(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            // Define the API endpoint constant
            const string apiEndpoint = "AuditQuestionnaires/{0}";
            // build API URL
            string url = string.Format(apiEndpoint, id);

            try
            {             
                // Send the GET request to the API endpoint
                var response = await httpClient.GetAsync(url);
                // Check if the response is null
                if (response.IsSuccessStatusCode) 
                {
                    var content = await response.Content.ReadFromJsonAsync<AuditQuestionnaireDetailDTO>();
                    if (content == null) {
                        Console.Error.WriteLine("The API returned a null response.");
                        throw new InvalidOperationException("The API returned a null response.");
                    }
                    return content;                    
                }
                else
                {
                    // Handle non-successful responses
                    Console.Error.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                    throw new Exception($"Error retrieving questionnaire with ID {id}", new Exception($"HTTP request failed with status code: {response.StatusCode}"));
                }
                
            }
            catch (HttpRequestException ex)
            {
                // Capture and log the error
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                // Capture and log the error
                Console.Error.WriteLine($"An unexpected error occurred while retrieving questionnaire with ID {id}: {ex.Message}");
                throw;
            }
        }


        public async Task<AuditQuestionnaireDetailDTO> GetAuditQuestionnaireDTOByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Error.WriteLine("Invalid name.");
                throw new ArgumentException("Name must not be null or whitespace.", nameof(name));
            }

            // Define the API endpoint constant
            const string apiEndpoint = "AuditQuestionnaires/{0}/ByName";
            string url = string.Format(apiEndpoint, name);

            try
            {
                
                var response = await httpClient.GetAsync(url);
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
                    throw new Exception($"Error retrieving questionnaire with name {name}", new Exception($"HTTP request failed with status code: {response.StatusCode}"));
                }
                
            }
            catch (HttpRequestException ex)
            {
                // Caputch HTTP request related exceptions
                Console.Error.WriteLine($"HTTP request failed for name {name}: {ex.Message}");
                throw new Exception($"Error retrieving questionnaire with name {name}", ex);
            }
            catch (Exception ex)
            {
                // Caputch other unexpected exceptions
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
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            const string apiEndpoint = "AuditQuestionnaires/{0}/MultipleChoiceQuestionsByIsDisplayPriority";
            string url = string.Format(apiEndpoint, id);

            try
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException($"HTTP request failed with status code: {response.StatusCode} for ID: {id}");
                }
                var content = await response.Content.ReadFromJsonAsync<List<MultipleChoiceQuestionDTO>>();
                if (content == null)
                {
                    Console.Error.WriteLine($"Failed to retrieve questionnaire with ID: {id}");
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }

                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }
            catch (Exception ex) when (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Unexpected error for ID {id}: {ex.Message}");
                throw;
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
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}/OpenQuestionsByAuditQuestionnaireId";
            string url = string.Format(apiEndpoint, id);
            try
            {               
                var response = await httpClient.GetAsync(url);
                if (response == null)
                {
                    Console.Error.WriteLine($"Failed to retrieve questionnaire with ID: {id}");
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }
                var content = await response.Content.ReadFromJsonAsync<List<OpenQuestionDTO>>();
                if (content == null)
                {
                    Console.Error.WriteLine($"Failed to retrieve questionnaire with ID: {id}");
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request failed for ID {id}: {ex.Message}");
                throw;
            }            
            catch (Exception ex) when  (ex is not HttpRequestException)
            {
                Console.Error.WriteLine($"Error retrieving questionnaire with ID {id}: {ex.Message}");
                throw;
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

        
        //public async Task<HttpResponseMessage> GetSelectListQuestionDTOsByQuestionnaireId(int id)
        public async Task<List<SelectListQuestionDTO>> GetSelectListQuestionDTOsByQuestionnaireId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            const string apiEndpoint = "AuditQuestionnaires/{0}/SelectListQuestionsByAuditQuestionnaireId";
            string url = string.Format(apiEndpoint, id);
            try
            {                
                var response = await httpClient.GetAsync(url);
                if (response == null)
                {
                    Console.Error.WriteLine($"Failed to retrieve questionnaire with ID: {id}");
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }
                var content = await response.Content.ReadFromJsonAsync<List<SelectListQuestionDTO>>();
                if (content == null)
                {
                    Console.Error.WriteLine($"Failed to retrieve questionnaire with ID: {id}");
                    throw new InvalidOperationException($"Failed to retrieve questionnaire with ID: {id}");
                }
                return content;
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
