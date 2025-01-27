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
    public class GetSelectListByIdQuery : IRequest<SelectListQuestionDTO>
    {
        public int Id { get; set; }
    }

    public class GetSelectListByIdQueryHandler : IRequestHandler<GetSelectListByIdQuery, SelectListQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetSelectListByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<SelectListQuestionDTO> Handle(GetSelectListByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<SelectListQuestionDTO>(await uow.SelectListQuestionRepository.GetById(request.Id));
        }
    }

}
