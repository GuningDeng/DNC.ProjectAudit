using DNC.ProjectAudit.Application;
using DNC.ProjectAudit.Application.Interfaces.InterfacesPeople;
using DNC.ProjectAudit.Domain.Entities.Enums;
using DNC.ProjectAudit.Domain.Entities.Person;
using DNC.ProjectAudit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Repositories.PeopleRepositories
{
    public class SupervisorRepository : GenericRepository<Supervisor>, ISupervisorRepository
    {
        private readonly DNCProjectAuditContext context;

        public SupervisorRepository(DNCProjectAuditContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<PagedResult<Supervisor>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10)
        {
            var result = new PagedResult<Supervisor>();
            result.PageNumber = pageNumber;
            result.PageSize = pageLength;

            IQueryable<Supervisor> query = context.Supervisors;

            result.TotalRecordCount = query.Count();

            if (nameFilter != null)
                query = query.Where(p => p.FirstName!.Contains(nameFilter));

            result.FilteredRecordCount = query.Count();
            result.TotalNumberOfPages = (int)Math.Ceiling((double)result.FilteredRecordCount / result.PageSize);

            switch (sortBy)
            {
                case SortBy.ByNameAscending:
                    query = query.OrderBy(p => p.FirstName);
                    break;
                case SortBy.ByNameDescending:
                    query = query.OrderByDescending(p => p.FirstName);
                    break;
                default:
                    break;
            }

            query = query.Skip((pageNumber - 1) * pageLength).Take(pageLength);

            result.Data = await query.ToListAsync();
            return result;

        }

        public async Task<IEnumerable<Supervisor>> GetAllSupervisors()
        {
            return await context.Supervisors.ToListAsync();
        }

        
        public async Task<IEnumerable<Supervisor>> GetSupervisorsByProjectManagerId(int id)
        {
            return await context.Supervisors.Where(s => s.SupervisorProjectManagerId == id).ToListAsync();
        }

        public async Task<IEnumerable<Supervisor>> GetSupervisorsByRegion(Region region)
        {
            return await context.Supervisors.Where(s => s.Region == region).ToListAsync();
        }
    }
}
