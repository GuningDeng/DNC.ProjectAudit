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
    public class GetMultipleChoiceQuestionByQuestionnaireIdAndByQuestionTextQuery : IRequest<MultipleChoiceQuestionDTO>
    {
        public int QuestionnaireId { get; set; }
        public string? QuestionText { get; set; }
    }

    public class GetMultipleChoiceQuestionByQuestionnaireIdAndByQuestionTextQueryHandler : IRequestHandler<GetMultipleChoiceQuestionByQuestionnaireIdAndByQuestionTextQuery, MultipleChoiceQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionByQuestionnaireIdAndByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<MultipleChoiceQuestionDTO> Handle(GetMultipleChoiceQuestionByQuestionnaireIdAndByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<MultipleChoiceQuestionDTO>(await uow.MultipleChoiceQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.QuestionnaireId, request.QuestionText!));
        }
    }
}
