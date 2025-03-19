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

namespace DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions
{
    public class AddOpenQuestionCommand : IRequest<OpenQuestionDTO>
    {
        public OpenQuestionDTO? OpenQuestion { get; set; }
    }

    public class AddOpenQuestionCommandValidator : AbstractValidator<AddOpenQuestionCommand>
    {
        private readonly IUnitofWork uow;

        public AddOpenQuestionCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(o => o.OpenQuestion!.QuestionText)
                .NotNull()
                .WithMessage("Question text cannot be empty");

            RuleFor(o => o.OpenQuestion!.QuestionText)
                .Length(8, 512)
                .WithMessage("Question text character length must be between 8 and 512");

            RuleFor(o => o.OpenQuestion!.AnswerText)
                .MaximumLength(2048)
                .WithMessage("Text character length must be between 8 and 2048");

            RuleFor(o => o.OpenQuestion!.QuestionAuditQuestionnaireId)
                .MustAsync(async (id, cancellation) =>
                {
                    var audit = await uow.OpenQuestionRepository.GetQuestionsByAudtiQuestionnaireId(id);
                    return (audit != null);
                })
                .WithMessage("The audit assignment does not exist");

        }
    }

    public class AddOpenQuestionCommandHandler : IRequestHandler<AddOpenQuestionCommand, OpenQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public AddOpenQuestionCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<OpenQuestionDTO> Handle(AddOpenQuestionCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.OpenQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.OpenQuestion!.QuestionAuditQuestionnaireId, request.OpenQuestion.QuestionText!);
            if (existing != null) throw new ValidationException("There is already a question with the same questiontext.");

            await uow.OpenQuestionRepository.Create(mapper.Map<OpenQuestion>(request.OpenQuestion));
            await uow.Commit();
            return request.OpenQuestion!;
        }
    }

}
