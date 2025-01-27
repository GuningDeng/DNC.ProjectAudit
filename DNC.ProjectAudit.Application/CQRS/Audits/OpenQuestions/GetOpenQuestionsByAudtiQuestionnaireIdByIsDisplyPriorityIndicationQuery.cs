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
    public class GetOpenQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery : IRequest<IEnumerable<OpenQuestionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetOpenQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQueryHandler : IRequestHandler<GetOpenQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery, IEnumerable<OpenQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetOpenQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OpenQuestionDTO>> Handle(GetOpenQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<OpenQuestionDTO>>(await uow.OpenQuestionRepository.GetOpenQuestionsByAudtiQuestionnaireIdAndByDisplyPriorityIndication(request.Id));
        }
    }

}
