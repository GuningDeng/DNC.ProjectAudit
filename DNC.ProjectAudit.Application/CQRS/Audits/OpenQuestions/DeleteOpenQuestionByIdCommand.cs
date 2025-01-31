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
    public class DeleteOpenQuestionByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteOpenQuestionByIdCommandHandler : IRequestHandler<DeleteOpenQuestionByIdCommand, int>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteOpenQuestionByIdCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<int> Handle(DeleteOpenQuestionByIdCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.OpenQuestionRepository.GetById(request.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");

            uow.OpenQuestionRepository.Delete(existing);
            await uow.Commit();
            return existing.Id;
        }
    }
}
