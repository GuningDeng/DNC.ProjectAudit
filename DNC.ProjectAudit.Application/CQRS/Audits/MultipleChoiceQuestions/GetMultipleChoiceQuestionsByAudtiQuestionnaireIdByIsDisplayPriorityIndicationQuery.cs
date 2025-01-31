using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions
{
    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery : IRequest<IEnumerable<MultipleChoiceQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQueryHandler : IRequestHandler<GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery, IEnumerable<MultipleChoiceQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDTO>> Handle(GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<MultipleChoiceQuestionDTO>>(await uow.MultipleChoiceQuestionRepository.GetQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndication(request.Id));
        }
    }
}
