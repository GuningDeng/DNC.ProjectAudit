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
    public class GetAllSelectListsQuery : IRequest<IEnumerable<SelectListQuestionDTO>>
    {
    }

    public class GetAllSelectListsQueryHandler : IRequestHandler<GetAllSelectListsQuery, IEnumerable<SelectListQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllSelectListsQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SelectListQuestionDTO>> Handle(GetAllSelectListsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<SelectListQuestionDTO>>(await uow.SelectListQuestionRepository.GetAllOpenQuestions());
        }
    }

}
