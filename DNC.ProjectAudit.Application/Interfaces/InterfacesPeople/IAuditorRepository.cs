﻿using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces.InterfacesPeople
{
    public interface IAuditorRepository : IGenericRepository<Auditor>
    {
        Task<Auditor> GetAuditor();
    }
}
