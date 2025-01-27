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
    public class GetMultipleChoiceQuestionByIdQuery : IRequest<MultipleChoiceQuestionDTO>
    {
        public int Id { get; set; }
    }

    public class GetMultipleChoiceQuestionByIdQueryHandler : IRequestHandler<GetMultipleChoiceQuestionByIdQuery, MultipleChoiceQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetMultipleChoiceQuestionByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<MultipleChoiceQuestionDTO> Handle(GetMultipleChoiceQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<MultipleChoiceQuestionDTO>(await uow.MultipleChoiceQuestionRepository.GetById(request.Id));
        }
    }


}
