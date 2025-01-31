using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions
{
    public class DeleteSelectListQuestionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteSelectListQuestionCommandHandler : IRequestHandler<DeleteSelectListQuestionCommand, int>
    {
        private readonly IUnitofWork uow;

        public DeleteSelectListQuestionCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(DeleteSelectListQuestionCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.SelectListQuestionRepository.GetById(request.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");

            uow.SelectListQuestionRepository.Delete(existing);
            await uow.Commit();
            return existing.Id;
        }
    }

}
