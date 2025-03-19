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
    public class GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQuery : IRequest<SelectListQuestionDTO>
    {
        public int QuestionnaireId { get; set; }
        public string? QuestionText { get; set; }
    }

    public class GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQueryHandler : IRequestHandler<GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQuery, SelectListQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<SelectListQuestionDTO> Handle(GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<SelectListQuestionDTO>(await uow.SelectListQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.QuestionnaireId, request.QuestionText!));
        }
    }
}
