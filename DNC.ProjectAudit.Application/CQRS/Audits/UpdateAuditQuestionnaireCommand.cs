using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits
{
    public class UpdateAuditQuestionnaireCommand : IRequest<AuditQuestionnaireDetailDTO>
    {
        public AuditQuestionnaireDetailDTO? AuditQuestionnaire { get; set; }
    }

    public class UpdateAuditQuestionnaireCommandHandler : IRequestHandler<UpdateAuditQuestionnaireCommand, AuditQuestionnaireDetailDTO>
    {
        private readonly IUnitofWork uow;

        public UpdateAuditQuestionnaireCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<AuditQuestionnaireDetailDTO> Handle(UpdateAuditQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.AuditQuestionnaireRepository.GetById(request.AuditQuestionnaire!.Id);
            if (existing == null) throw new KeyNotFoundException("Questionnaire does not exist");
            if (existing.Name != request.AuditQuestionnaire.Name)
            {
                var exist = uow.AuditQuestionnaireRepository.GetByTitle(existing.Name!);
                if (exist != null) throw new ValidationException("The Question already exists");
            }

            existing.Name = request.AuditQuestionnaire.Name;
            existing.Description = request.AuditQuestionnaire.Description;
            existing.Region = request.AuditQuestionnaire.Region;
            existing.CreatedBy = request.AuditQuestionnaire.CreatedBy;
            existing.UpdatedBy = request.AuditQuestionnaire.UpdatedBy;
            existing.DeletedBy = request.AuditQuestionnaire.DeletedBy;
            existing.CreatedDate = request.AuditQuestionnaire.CreatedDate;
            existing.SubmissionDeadline = request.AuditQuestionnaire.SubmissionDeadline;
            existing.SubmittedBySupervisorsText = request.AuditQuestionnaire.SubmittedBySupervisorsText;
            existing.ApprovedByProjetManagerId = request.AuditQuestionnaire.ApprovedByProjetManagerId;
            existing.IsStarted = request.AuditQuestionnaire.IsStarted;
            existing.IsCompleted = request.AuditQuestionnaire.IsCompleted;

            uow.AuditQuestionnaireRepository.Update(existing);
            await uow.Commit();
            return request.AuditQuestionnaire;

        }
    } 
}
