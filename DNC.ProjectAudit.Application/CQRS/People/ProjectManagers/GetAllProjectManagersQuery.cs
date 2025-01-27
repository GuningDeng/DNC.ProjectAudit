using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.People.ProjectManagers
{
    public class GetAllProjectManagersQuery : IRequest<IEnumerable<ProjectManagerDetailDTO>>
    {

    }

    public class GetAllProjectManagersQueryHandler : IRequestHandler<GetAllProjectManagersQuery, IEnumerable<ProjectManagerDetailDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllProjectManagersQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProjectManagerDetailDTO>> Handle(GetAllProjectManagersQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<ProjectManagerDetailDTO>>(await uow.ProjectManagerRepository.GetAllProjectManagers());
        }
    } 
}
