using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions
{
    public class AddMultipleChoiceQuestionCommand : IRequest<MultipleChoiceQuestionDTO>
    {
        public MultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
    public class AddMultipleChoiceQuestionCommandValidator : AbstractValidator<AddMultipleChoiceQuestionCommand>
    {
        private readonly IUnitofWork uow;

        public AddMultipleChoiceQuestionCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(m => m.MultipleChoiceQuestion!.QuestionText)
                .NotNull()
                .WithMessage("Question text cannot be empty");

            RuleFor(m => m.MultipleChoiceQuestion!.QuestionText)
                .Length(8, 512)
                .WithMessage("Question text character length must be between 8 and 512");


            RuleFor(m => m.MultipleChoiceQuestion!.OptionText)
                .NotNull()
                .WithMessage("Option text cannot be empty");

            RuleFor(m => m.MultipleChoiceQuestion!.OptionText)
                .Length(8, 2048)
                .WithMessage("Option text character length must be between 8 and 2048");

            RuleFor(m => m.MultipleChoiceQuestion!.QuestionAuditQuestionnaireId)
                .MustAsync(async (id, cancellation) =>
                {
                    var audit = await uow.AuditQuestionnaireRepository.GetById(id);
                    return (audit != null);
                })
                .WithMessage("The audit assignment does not exist");

        }
    }

    public class AddMultipleChoiceQuestionCommandHandler : IRequestHandler<AddMultipleChoiceQuestionCommand, MultipleChoiceQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public AddMultipleChoiceQuestionCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// There cannot be repeated questions in a questionnaire.
        /// Check whether the question text and questionnaire id already exist.
        /// If the question text and questionnaire id already exist,
        /// the save request will be aborted.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<MultipleChoiceQuestionDTO> Handle(AddMultipleChoiceQuestionCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.MultipleChoiceQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.MultipleChoiceQuestion!.QuestionAuditQuestionnaireId, request.MultipleChoiceQuestion.QuestionText!);
            if(existing != null) throw new ValidationException("There is already a question with the same questiontext.");
            
            await uow.MultipleChoiceQuestionRepository.Create(mapper.Map<MultipleChoiceQuestion>(request.MultipleChoiceQuestion));
            await uow.Commit();
            return request.MultipleChoiceQuestion;
        }
    }


}
