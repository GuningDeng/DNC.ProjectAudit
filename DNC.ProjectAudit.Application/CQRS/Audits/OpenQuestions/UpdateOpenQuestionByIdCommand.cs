using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions
{
    public class UpdateOpenQuestionByIdCommand : IRequest<OpenQuestionDTO>
    {
        public OpenQuestionDTO? OpenQuestion { get; set; }
    }

    public class UpdateOpenQuestionByIdCommandHandler : IRequestHandler<UpdateOpenQuestionByIdCommand, OpenQuestionDTO>
    {
        private readonly IUnitofWork uow;

        public UpdateOpenQuestionByIdCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<OpenQuestionDTO> Handle(UpdateOpenQuestionByIdCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.OpenQuestionRepository.GetById(request.OpenQuestion!.Id);
            if (existing == null) throw new KeyNotFoundException("Question does not exist");
            if (existing.QuestionText != request.OpenQuestion.QuestionText)
            {
                var exist = uow.OpenQuestionRepository.GetQuestionByQuestionText(request.OpenQuestion.QuestionText!);
                if (exist != null) throw new ValidationException("The Question already exists");
                
            }

            existing.QuestionText = request.OpenQuestion.QuestionText;
            existing.AnswerText = request.OpenQuestion.AnswerText;
            existing.IsDisplay = request.OpenQuestion.IsDisplay;
            existing.PriorityIndication = request.OpenQuestion.PriorityIndication;
            existing.QuestionAuditQuestionnaireId = request.OpenQuestion.QuestionAuditQuestionnaireId;

            uow.OpenQuestionRepository.Update(existing);
            await uow.Commit();
            return request.OpenQuestion;
        }
    } 
}
