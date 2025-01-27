using DNC.ProjectAudit.Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions
{
    public class AddSelectListQuestionCommand : IRequest<SelectListQuestionDTO>
    {
        public SelectListQuestionDTO? SelectListQuestion { get; set; }
    }

    public class AddOpenSelectListCommandValidator : AbstractValidator<AddSelectListQuestionCommand>
    {
        private readonly IUnitofWork uow;

        public AddOpenSelectListCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(o => o.SelectListQuestion!.QuestionText)
                .NotNull()
                .WithMessage("Question text cannot be empty");

            RuleFor(o => o.SelectListQuestion!.QuestionText)
                .Length(8, 512)
                .WithMessage("Question text cannot be longer than 512 letters");


            RuleFor(o => o.SelectListQuestion!.OptionText)
                .NotNull()
                .WithMessage("Option text cannot be empty");

            RuleFor(o => o.SelectListQuestion!.OptionText)
                .Length(8, 2048)
                .WithMessage("Option text cannot be longer than 512 letters");

            RuleFor(o => o.SelectListQuestion!.QuestionAuditQuestionnaireId)
                .MustAsync(async (id, cancellation) =>
                {
                    var audit = await uow.AuditQuestionnaireRepository.GetById(id);
                    return (audit != null);
                })
                .WithMessage("The audit assignment does not exist");

        }
    }

}
