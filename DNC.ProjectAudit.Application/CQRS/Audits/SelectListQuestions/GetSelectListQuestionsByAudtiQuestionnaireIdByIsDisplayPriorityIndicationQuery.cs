using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions
{
    public class GetSelectListQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery : IRequest<IEnumerable<SelectListQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSelectListQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQueryHandler : IRequestHandler<GetSelectListQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery, IEnumerable<SelectListQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetSelectListQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SelectListQuestionDTO>> Handle(GetSelectListQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<SelectListQuestionDTO>>(await uow.SelectListQuestionRepository.GetSelectListQuestionsByAudtiQuestionnaireIdAndByDisplayPriorityIndication(request.Id));
        }
    }
}
