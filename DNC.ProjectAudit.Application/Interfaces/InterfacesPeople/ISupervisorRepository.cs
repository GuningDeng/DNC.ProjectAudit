using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesPeople
{
    public interface ISupervisorRepository : IGenericRepository<Supervisor>
    {
        Task<PagedResult<Supervisor>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10);
        Task<IEnumerable<Supervisor>> GetAllSupervisors();
        Task<IEnumerable<Supervisor>> GetSupervisorsByProjectManagerId(int id);
        Task<IEnumerable<Supervisor>> GetSupervisorsByRegion(Region region);
    }
}
