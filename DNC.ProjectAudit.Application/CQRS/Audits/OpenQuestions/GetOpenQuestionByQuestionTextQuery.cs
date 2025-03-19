using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions
{
    public class GetOpenQuestionByQuestionTextQuery : IRequest<OpenQuestionDTO>
    {
        public string? QuestionText { get; set; }
    }

    public class GetOpenQuestionByQuestionTextQueryHandler : IRequestHandler<GetOpenQuestionByQuestionTextQuery, OpenQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetOpenQuestionByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<OpenQuestionDTO> Handle(GetOpenQuestionByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<OpenQuestionDTO>(await uow.OpenQuestionRepository.GetByQuestionText(request.QuestionText!));
        }
    }
}
