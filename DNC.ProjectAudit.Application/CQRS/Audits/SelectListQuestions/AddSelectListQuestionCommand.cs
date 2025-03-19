using AutoMapper;
using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Application.Interfaces.InterfacesAuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
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
                .WithMessage("Question text character length must be between 8 and 512.");


            RuleFor(o => o.SelectListQuestion!.OptionText)
                .NotNull()
                .WithMessage("Option text cannot be empty");

            RuleFor(o => o.SelectListQuestion!.OptionText)
                .Length(8, 2048)
                .WithMessage("Option text text character length must be between 8 and 2048");

            RuleFor(o => o.SelectListQuestion!.QuestionAuditQuestionnaireId)
                .MustAsync(async (id, cancellation) =>
                {
                    var audit = await uow.AuditQuestionnaireRepository.GetById(id);
                    return (audit != null);
                })
                .WithMessage("The audit assignment does not exist");

        }
    }

    public class AddSelectListQuestionCommandhandler : IRequestHandler<AddSelectListQuestionCommand, SelectListQuestionDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public AddSelectListQuestionCommandhandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<SelectListQuestionDTO> Handle(AddSelectListQuestionCommand request, CancellationToken cancellationToken)
        {
            var existing = await uow.SelectListQuestionRepository.GetQuestionByQuestionnaireIdAndQuestionText(request.SelectListQuestion!.QuestionAuditQuestionnaireId, request.SelectListQuestion.QuestionText!);
            if (existing != null) throw new ValidationException("There is already a question with the same questiontext.");

            await uow.SelectListQuestionRepository.Create(mapper.Map<SelectListQuestion>(request.SelectListQuestion));
            await uow.Commit();
            return request.SelectListQuestion;
        }
    }

}
