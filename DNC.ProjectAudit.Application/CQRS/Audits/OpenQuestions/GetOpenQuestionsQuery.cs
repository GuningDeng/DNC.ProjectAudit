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
    public class GetOpenQuestionsQuery : IRequest<IEnumerable<OpenQuestionDTO>>
    {
        
    }

    public class GetOpenQuestionsQueryHnadler : IRequestHandler<GetOpenQuestionsQuery, IEnumerable<OpenQuestionDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetOpenQuestionsQueryHnadler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OpenQuestionDTO>> Handle(GetOpenQuestionsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<OpenQuestionDTO>>(await uow.OpenQuestionRepository.GetAllOpenQuestions());
        }
    }
}
