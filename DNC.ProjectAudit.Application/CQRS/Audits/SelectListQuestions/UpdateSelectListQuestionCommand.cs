using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions
{
    public class UpdateSelectListQuestionCommand : IRequest<SelectListQuestionDTO>
    {
        public SelectListQuestionDTO? SelectListQuestion { get; set; }
    }

    public class UpdateSelectListQuestionCommandHandler : IRequestHandler<UpdateSelectListQuestionCommand, SelectListQuestionDTO>
    {
        private readonly IUnitofWork uow;

        public UpdateSelectListQuestionCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<SelectListQuestionDTO> Handle(UpdateSelectListQuestionCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.SelectListQuestionRepository.GetById(request.SelectListQuestion!.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");
            if (existing.QuestionText != request.SelectListQuestion.QuestionText)
            {
                var exist = uow.SelectListQuestionRepository.GetQuestionByQuestionText(request.SelectListQuestion.QuestionText!);
                if (exist != null) throw new ValidationException("The Question already exists");
            }

            existing.QuestionText = request.SelectListQuestion.QuestionText;
            existing.AnswerText = request.SelectListQuestion.AnswerText;
            existing.OptionText = request.SelectListQuestion.OptionText;
            existing.IsDisplay = request.SelectListQuestion.IsDisplay;
            existing.PriorityIndication = request.SelectListQuestion.PriorityIndication;
            existing.QuestionAuditQuestionnaireId = request.SelectListQuestion.QuestionAuditQuestionnaireId;

            uow.SelectListQuestionRepository.Update(existing);
            await uow.Commit();
            return request.SelectListQuestion;

        }
    }

}
