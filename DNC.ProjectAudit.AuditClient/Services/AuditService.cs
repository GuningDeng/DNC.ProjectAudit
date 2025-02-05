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
            return await _httpClient.GetFromJsonAsync<AuditorDTO>($"auditors/Auditor");
        }

         
    }
}
