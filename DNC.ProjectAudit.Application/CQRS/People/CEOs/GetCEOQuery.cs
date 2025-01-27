using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.People.CEOs
{
    public class GetCEOQuery : IRequest<CEODTO>
    {
        //public CEODTO? CEODTO { get; set; }
    }

    public class GetCEOQueryHandler : IRequestHandler<GetCEOQuery, CEODTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetCEOQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<CEODTO> Handle(GetCEOQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<CEODTO>(await uow.ICEORepository.GetCEO());
        }
    }

}
