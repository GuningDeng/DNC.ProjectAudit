using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.People.Auditors
{
    public class GetAuditorQuery : IRequest<AuditorDTO>
    {
        //public int Id { get; set; }
    }

    public class GetAuditorQueryHandler : IRequestHandler<GetAuditorQuery, AuditorDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAuditorQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<AuditorDTO> Handle(GetAuditorQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<AuditorDTO>(await uow.AuditorRepository.GetAuditor());
        }
    }

}
