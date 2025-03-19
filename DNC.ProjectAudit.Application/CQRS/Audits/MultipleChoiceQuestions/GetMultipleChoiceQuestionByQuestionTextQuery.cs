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
    public class GetMultipleChoiceQuestionByQuestionTextQuery : IRequest<MultipleChoiceQuestionDTO>
    {
        public string? QuestionText { get; set; }
    }

    public class GetMultipleChoiceQuestionByQuestionTextQueryHandler : IRequestHandler<GetMultipleChoiceQuestionByQuestionTextQuery, MultipleChoiceQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<MultipleChoiceQuestionDTO> Handle(GetMultipleChoiceQuestionByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<MultipleChoiceQuestionDTO>(await uow.MultipleChoiceQuestionRepository.GetQuestionByQuestionText(request.QuestionText!));
        }
    }


}
