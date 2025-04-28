using DNC.ProjectAudit.Application.CQRS.People.ProjectManagers;
using DNC.ProjectAudit.Application.CQRS.People.Supervisors;
using DNC.ProjectAudit.Domain.Entities.Person;
using System.Net.Http.Json;

namespace DNC.ProjectAudit.EmployeeClient.Services
{
    public class EmployeeService
    {
        private const string ProjectManagersApiPath = "ProjectManagers";

        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProjectManagerDTO>> GetProjectManagerDTOs()
        {
            var response = await _httpClient.GetAsync(ProjectManagersApiPath);
            response.EnsureSuccessStatusCode();

            if (response.Content == null)
            {
                throw new InvalidOperationException("Response content is null.");
            }

            var projectManagers = await _httpClient.GetFromJsonAsync<List<ProjectManagerDTO>>(ProjectManagersApiPath);

            if (projectManagers == null)
            {
                throw new InvalidOperationException("Failed to retrieve auditor.");
            }

            return projectManagers ?? [];
        }

        public async Task<ProjectManagerDTO> GetLastProjectManagerDTOAsync()
        {
            var projectManagers = await GetProjectManagerDTOs();
            return projectManagers.Last();
        }
    }
}
