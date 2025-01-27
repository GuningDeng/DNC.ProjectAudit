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
    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQuery : IRequest<IEnumerable<MultipleChoiceQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQueryHandler : IRequestHandler<GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQuery, IEnumerable<MultipleChoiceQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDTO>> Handle(GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<MultipleChoiceQuestionDTO>>(await uow.MultipleChoiceQuestionRepository.GetQuestionsByAudtiQuestionnaireId(request.Id));
        }
    }
}
