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
    public class GetAllAuditQuestionnairesQuickQuery : IRequest<IEnumerable<AuditQuestionnaireDTO>>
    {

    }

    public class GetAllAuditQuestionnairesQuickQueryHandler : IRequestHandler<GetAllAuditQuestionnairesQuickQuery, IEnumerable<AuditQuestionnaireDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllAuditQuestionnairesQuickQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AuditQuestionnaireDTO>> Handle(GetAllAuditQuestionnairesQuickQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<AuditQuestionnaireDTO>>(await uow.AuditQuestionnaireRepository.GetAllAuditQuestionnaires());
        }
    }

}
