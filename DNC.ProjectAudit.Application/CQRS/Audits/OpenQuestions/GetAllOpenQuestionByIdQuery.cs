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
    public class GetAllOpenQuestionByIdQuery : IRequest<OpenQuestionDTO>
    {
        public int Id { get; set; }
    }

    public class GetAllOpenQuestionByIdQueryHandler : IRequestHandler<GetAllOpenQuestionByIdQuery, OpenQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllOpenQuestionByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<OpenQuestionDTO> Handle(GetAllOpenQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<OpenQuestionDTO>(await uow.OpenQuestionRepository.GetById(request.Id));
        }
    }
}
