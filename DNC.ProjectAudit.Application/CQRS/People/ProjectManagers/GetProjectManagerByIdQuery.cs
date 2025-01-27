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
    public class GetProjectManagerByIdQuery : IRequest<ProjectManagerDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetProjectManagerByIdQueryHandler : IRequestHandler<GetProjectManagerByIdQuery, ProjectManagerDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetProjectManagerByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ProjectManagerDetailDTO> Handle(GetProjectManagerByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<ProjectManagerDetailDTO>(await uow.ProjectManagerRepository.GetById(request.Id));
        }
    }

}
