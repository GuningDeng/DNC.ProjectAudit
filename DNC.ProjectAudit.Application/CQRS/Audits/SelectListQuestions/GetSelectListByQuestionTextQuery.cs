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
    public class GetSelectListByQuestionTextQuery : IRequest<SelectListQuestionDTO>
    {
        public string? QuestionText { get; set; }
    }

    public class GetSelectListByQuestionTextQueryHandler : IRequestHandler<GetSelectListByQuestionTextQuery, SelectListQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetSelectListByQuestionTextQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<SelectListQuestionDTO> Handle(GetSelectListByQuestionTextQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<SelectListQuestionDTO>(await uow.SelectListQuestionRepository.GetByQuestionText(request.QuestionText!));
        }
    }
}
