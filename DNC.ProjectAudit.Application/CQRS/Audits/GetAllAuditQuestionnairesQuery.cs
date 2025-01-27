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
    public class GetAllAuditQuestionnairesQuery : IRequest<IEnumerable<AuditQuestionnaireDetailDTO>>
    {

    }

    public class GetAllAuditQuestionnairesQueryHnadler : IRequestHandler<GetAllAuditQuestionnairesQuery, IEnumerable<AuditQuestionnaireDetailDTO>> 
    { 
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllAuditQuestionnairesQueryHnadler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AuditQuestionnaireDetailDTO>> Handle(GetAllAuditQuestionnairesQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<AuditQuestionnaireDetailDTO>>(await uow.AuditQuestionnaireRepository.GetAllAuditQuestionnaires());
        }
    }
}
