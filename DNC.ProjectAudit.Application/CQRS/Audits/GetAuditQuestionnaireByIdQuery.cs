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
    public class GetAuditQuestionnaireByIdQuery : IRequest<AuditQuestionnaireDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetAuditQuestionnaireByIdQueryHandler : IRequestHandler<GetAuditQuestionnaireByIdQuery, AuditQuestionnaireDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAuditQuestionnaireByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<AuditQuestionnaireDetailDTO> Handle(GetAuditQuestionnaireByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<AuditQuestionnaireDetailDTO>(await uow.AuditQuestionnaireRepository.GetById(request.Id));
        }
    }
}
