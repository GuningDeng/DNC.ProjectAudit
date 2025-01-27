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
    public class CEORepository : GenericRepository<CEO>, ICEORepository
    {
        private readonly DNCProjectAuditContext context;

        public CEORepository(DNCProjectAuditContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<CEO> GetCEO()
        {
            return await context.CEOs!.FirstOrDefaultAsync();
        }
    }
}
