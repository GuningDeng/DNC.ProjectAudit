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
    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery : IRequest<IEnumerable<MultipleChoiceQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQueryHandler : IRequestHandler<GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery, IEnumerable<MultipleChoiceQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDTO>> Handle(GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<MultipleChoiceQuestionDTO>>(await uow.MultipleChoiceQuestionRepository.GetQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndication(request.Id));
        }
    }
}
