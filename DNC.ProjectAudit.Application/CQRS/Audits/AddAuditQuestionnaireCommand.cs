using AutoMapper;
using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = DNC.ProjectAudit.Application.Exceptions.ValidationException;

namespace DNC.ProjectAudit.Application.CQRS.Audits
{
    public class AddAuditQuestionnaireCommand : IRequest<AuditQuestionnaireDetailDTO>
    {
        public AuditQuestionnaireDetailDTO? AuditQuestionnaire { get; set; }
    }

    public class AddAuditQuestionnaireCommandValidator : AbstractValidator<AddAuditQuestionnaireCommand>
    {
        private readonly IUnitofWork uow;

        public AddAuditQuestionnaireCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(a => a.AuditQuestionnaire!.Name)
                .NotNull()
                .WithMessage("Name cannot be empty");

            RuleFor(a => a.AuditQuestionnaire!.Name)
                .Length(8, 128)
                .WithMessage("The name length is limited to between 8 and 128 characters.");
        }

        public class AddAuditQuestionnaireCommandHandler : IRequestHandler<AddAuditQuestionnaireCommand, AuditQuestionnaireDetailDTO>
        {
            private readonly IUnitofWork uow;
            private readonly IMapper mapper;

            public AddAuditQuestionnaireCommandHandler(IUnitofWork uow, IMapper mapper)
            {
                this.uow = uow;
                this.mapper = mapper;
            }

            public async Task<AuditQuestionnaireDetailDTO> Handle(AddAuditQuestionnaireCommand request, CancellationToken cancellationToken)
            {
                var existing = uow.AuditQuestionnaireRepository.GetByTitle(request.AuditQuestionnaire!.Name!);
                if (existing != null) throw new ValidationException("There is already a questionnaire with the same name.");

                await uow.AuditQuestionnaireRepository.Create(mapper.Map<AuditQuestionnaire>(request.AuditQuestionnaire!));
                await uow.Commit();
                return request.AuditQuestionnaire;
            }
        }
    }
}
