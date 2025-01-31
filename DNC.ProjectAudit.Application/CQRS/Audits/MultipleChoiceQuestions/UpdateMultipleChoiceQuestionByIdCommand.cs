using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions
{
    public class UpdateMultipleChoiceQuestionByIdCommand : IRequest<MultipleChoiceQuestionDTO>
    {
        public MultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }

    public class UpdateMultipleChoiceQuestionByIdCommandHandler : IRequestHandler<UpdateMultipleChoiceQuestionByIdCommand, MultipleChoiceQuestionDTO>
    {
        private readonly IUnitofWork uow;

        public UpdateMultipleChoiceQuestionByIdCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<MultipleChoiceQuestionDTO> Handle(UpdateMultipleChoiceQuestionByIdCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.MultipleChoiceQuestionRepository.GetById(request.MultipleChoiceQuestion!.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");
            if (existing.QuestionText != request.MultipleChoiceQuestion.QuestionText)
            {
                var exist = uow.MultipleChoiceQuestionRepository.GetByQuestionText(request.MultipleChoiceQuestion.QuestionText!);
                if (exist != null) throw new ValidationException("The Question already exists");
            }

            existing.OptionText = request.MultipleChoiceQuestion.OptionText;
            existing.OptionText = request.MultipleChoiceQuestion.OptionText;
            existing.AnswerText = request.MultipleChoiceQuestion.AnswerText;
            existing.IsDisplay = request.MultipleChoiceQuestion.IsDisplay;
            existing.PriorityIndication = request.MultipleChoiceQuestion.PriorityIndication;
            existing.QuestionAuditQuestionnaireId = request.MultipleChoiceQuestion.QuestionAuditQuestionnaireId;

            uow.MultipleChoiceQuestionRepository.Update(existing);
            await uow.Commit();
            return request.MultipleChoiceQuestion;

        }
    }

}
