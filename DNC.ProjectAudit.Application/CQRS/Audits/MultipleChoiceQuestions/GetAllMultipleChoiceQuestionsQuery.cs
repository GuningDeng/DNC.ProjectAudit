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
    public class GetAllMultipleChoiceQuestionsQuery : IRequest<IEnumerable<MultipleChoiceQuestionDTO>>
    {

    }

    public class GetAllMultipleChoiceQuestionsQueryHandler : IRequestHandler<GetAllMultipleChoiceQuestionsQuery, IEnumerable<MultipleChoiceQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllMultipleChoiceQuestionsQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDTO>> Handle(GetAllMultipleChoiceQuestionsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<MultipleChoiceQuestionDTO>>(await uow.MultipleChoiceQuestionRepository.GetAllMultipleChoiceQuestions());
        }
    }
}
