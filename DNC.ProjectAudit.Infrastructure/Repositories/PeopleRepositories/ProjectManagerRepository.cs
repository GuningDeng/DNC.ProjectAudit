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
    public class ProjectManagerRepository : GenericRepository<ProjectManager>, IProjectManagerRepository
    {
        private readonly DNCProjectAuditContext context;

        public ProjectManagerRepository(DNCProjectAuditContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<PagedResult<ProjectManager>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10)
        {
            var result = new PagedResult<ProjectManager>();
            result.PageNumber = pageNumber;
            result.PageSize = pageLength;

            IQueryable<ProjectManager> query = context.ProjectManagers;

            result.TotalRecordCount = query.Count();

            if (nameFilter != null)
                query = query.Where(p => p.FirstName!.Contains(nameFilter));

            result.FilteredRecordCount = query.Count();
            result.TotalNumberOfPages = (int)Math.Ceiling((double)result.FilteredRecordCount / result.PageSize);

            switch (sortBy) 
            {
                case SortBy.ByNameAscending:
                    query = query.OrderBy(p  => p.FirstName);
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

        public async Task<IEnumerable<ProjectManager>> GetAllProjectManagers()
        {
            return await context.ProjectManagers.ToListAsync();
        }

        public ProjectManager GetByEmail(string email)
        {
            return context.ProjectManagers.FirstOrDefault(p => p.Email == email)!;
        }

        public ProjectManager GetByMobilePhone(string phone)
        {
            return context.ProjectManagers.FirstOrDefault(p => p.MobilePhone == phone)!;
        }

        public ProjectManager GetByPhone(string phone)
        {
            return context.ProjectManagers.FirstOrDefault(p => p.OfficePhone == phone)!;
        }

        public async Task<IEnumerable<ProjectManager>> GetProjectManagersByRegion(Region region)
        {
            return await context.ProjectManagers.Where(p => p.Region == region).ToListAsync();
        }

        public async Task<IEnumerable<Supervisor>> GetSupervisorsByProjectManagerId(int id)
        {
            return await context.Supervisors.Where(s => s.SupervisorProjectManagerId == id).ToListAsync();
        }
    }
}
