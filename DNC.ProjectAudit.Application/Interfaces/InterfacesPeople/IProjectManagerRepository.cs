using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesPeople
{
    public interface IProjectManagerRepository : IGenericRepository<ProjectManager>
    {
        Task<PagedResult<ProjectManager>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10);
        Task<IEnumerable<ProjectManager>> GetAllProjectManagers();
        Task<IEnumerable<ProjectManager>> GetProjectManagersByRegion(Region region);
        ProjectManager GetByEmail(string email);
        ProjectManager GetByPhone(string phone);
        ProjectManager GetByMobilePhone(string phone);
        Task<IEnumerable<Supervisor>> GetSupervisorsByProjectManagerId(int id);
    }
}
