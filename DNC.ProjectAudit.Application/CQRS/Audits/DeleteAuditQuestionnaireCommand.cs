using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits
{
    public class DeleteAuditQuestionnaireCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteAuditQuestionnaireCommandHandler : IRequestHandler<DeleteAuditQuestionnaireCommand, int>
    {
        private readonly IUnitofWork uow;

        public DeleteAuditQuestionnaireCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(DeleteAuditQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.AuditQuestionnaireRepository.GetById(request.Id);
            if (existing == null) throw new KeyNotFoundException("Questionnaire does noet exist");
            
            uow.AuditQuestionnaireRepository.Delete(existing);
            await uow.Commit();
            return existing.Id;
        }
    }
}
