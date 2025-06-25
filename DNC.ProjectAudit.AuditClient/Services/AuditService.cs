using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.People.Auditors;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.AuditClient.Services
{
    public class AuditService
    {
        private readonly HttpClient _httpClient;

        public AuditService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuditorDTO> GetAuditorAsync()
        {
            const string ApiEndPoint = "Auditors/Auditor";
            try
            {
                var response = await _httpClient.GetAsync(ApiEndPoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<AuditorDTO>();
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
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex) when (ex is not InvalidOperationException)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            
        }

         
    }
}
