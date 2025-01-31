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
    public class GetSelectListQuestionsByAudtiQuestionnaireIdQuery : IRequest<IEnumerable<SelectListQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSelectListQuestionsByAudtiQuestionnaireIdQueryHandler : IRequestHandler<GetSelectListQuestionsByAudtiQuestionnaireIdQuery, IEnumerable<SelectListQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetSelectListQuestionsByAudtiQuestionnaireIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SelectListQuestionDTO>> Handle(GetSelectListQuestionsByAudtiQuestionnaireIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<SelectListQuestionDTO>>(await uow.SelectListQuestionRepository.GetAllSelectListQuestionsByAudtiQuestionnaireId(request.Id));
        }
    }

}
