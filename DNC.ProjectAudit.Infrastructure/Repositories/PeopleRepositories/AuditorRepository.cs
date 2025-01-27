using DNC.ProjectAudit.Application.Interfaces.InterfacesPeople;
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
    public class AuditorRepository : GenericRepository<Auditor>, IAuditorRepository
    {
        private readonly DNCProjectAuditContext context;

        public AuditorRepository(DNCProjectAuditContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Auditor> GetAuditor()
        {
            return await context.Auditors.FirstOrDefaultAsync();
        }
    }
}
