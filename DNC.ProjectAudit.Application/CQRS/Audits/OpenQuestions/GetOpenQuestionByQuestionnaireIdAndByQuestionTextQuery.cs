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
    public class GetOpenQuestionByQuestionnaireIdAndByQuestionTextQuery : IRequest<OpenQuestionDTO>
    {
        public int QuestionnaireId { get; set; }
        public string? QuestionText { get; set; }
    }

    public class GetOpenQuestionByQuestionnaireIdAndByQuestionTextQueryHandler: IRequestHandler<GetOpenQuestionByQuestionnaireIdAndByQuestionTextQuery, OpenQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetOpenQuestionByQuestionnaireIdAndByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<OpenQuestionDTO> Handle(GetOpenQuestionByQuestionnaireIdAndByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<OpenQuestionDTO>(await uow.OpenQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.QuestionnaireId, request.QuestionText!));
        }
    }
}
