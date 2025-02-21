using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits
{
    public class GetAuditQuestionnaireByNameQuery : IRequest<AuditQuestionnaireDetailDTO>
    {
        public string? Name { get; set; }
    }

    public class GetAuditQuestionnaireByNameQueryHandler : IRequestHandler<GetAuditQuestionnaireByNameQuery, AuditQuestionnaireDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAuditQuestionnaireByNameQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<AuditQuestionnaireDetailDTO> Handle(GetAuditQuestionnaireByNameQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<AuditQuestionnaireDetailDTO>(await uow.AuditQuestionnaireRepository.GetByName(request.Name!));
        }
    }
}
