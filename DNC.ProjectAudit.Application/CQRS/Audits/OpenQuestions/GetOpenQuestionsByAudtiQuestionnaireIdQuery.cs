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
    public class GetOpenQuestionsByAudtiQuestionnaireIdQuery : IRequest<IEnumerable<OpenQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetOpenQuestionsByAudtiQuestionnaireIdQueryHandler : IRequestHandler<GetOpenQuestionsByAudtiQuestionnaireIdQuery, IEnumerable<OpenQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetOpenQuestionsByAudtiQuestionnaireIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OpenQuestionDTO>> Handle(GetOpenQuestionsByAudtiQuestionnaireIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<OpenQuestionDTO>>(await uow.OpenQuestionRepository.GetQuestionsByAudtiQuestionnaireId(request.Id));
        }
    }
}
