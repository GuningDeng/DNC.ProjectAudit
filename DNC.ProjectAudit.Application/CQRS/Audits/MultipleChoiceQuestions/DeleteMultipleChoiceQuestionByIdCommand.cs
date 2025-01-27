using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions
{
    public class DeleteMultipleChoiceQuestionByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteMultipleChoiceQuestionByIdCommandHandler : IRequestHandler<DeleteMultipleChoiceQuestionByIdCommand, int>
    {
        private readonly IUnitofWork uow;

        public DeleteMultipleChoiceQuestionByIdCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(DeleteMultipleChoiceQuestionByIdCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.MultipleChoiceQuestionRepository.GetById(request.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");

            uow.MultipleChoiceQuestionRepository.Delete(existing);
            await uow.Commit();
            return existing.Id;
        }
    }
}
