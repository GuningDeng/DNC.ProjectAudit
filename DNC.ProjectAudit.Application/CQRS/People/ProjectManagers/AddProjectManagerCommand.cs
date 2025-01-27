using AutoMapper;
using DNC.ProjectAudit.Application.Exceptions;
using DNC.ProjectAudit.Application.Interfaces;
using DNC.ProjectAudit.Domain.Entities.Person;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = DNC.ProjectAudit.Application.Exceptions.ValidationException;

namespace DNC.ProjectAudit.Application.CQRS.People.ProjectManagers
{
    public class AddProjectManagerCommand : IRequest<ProjectManagerDetailDTO>
    {
        public ProjectManagerDetailDTO? ProjectManager { get; set; }
    }

    public class AddProjectManagerCommandValidator : AbstractValidator<AddProjectManagerCommand>
    {
        private IUnitofWork uow;

        public AddProjectManagerCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(p => p.ProjectManager!.FirstName)
                .NotNull()
                .WithMessage("Firstname cannot be empty");

            RuleFor(p => p.ProjectManager!.FirstName)
                .Length(2, 128)
                .WithMessage("Firstname length is limited to between 8 and 128 characters.");

            RuleFor(p => p.ProjectManager!.LastName)
                .NotNull()
                .WithMessage("Lastname cannot be empty");

            RuleFor(p => p.ProjectManager!.LastName)
                .Length(2, 128)
                .WithMessage("Lastname length is limited to between 8 and 128 characters.");

        }

        public class AddProjectManagerCommandHandler : IRequestHandler<AddProjectManagerCommand, ProjectManagerDetailDTO>
        {
            private IUnitofWork uow;
            private IMapper mapper;

            public AddProjectManagerCommandHandler(IUnitofWork uow, IMapper mapper)
            {
                this.uow = uow;
                this.mapper = mapper;
            }

            public async Task<ProjectManagerDetailDTO> Handle(AddProjectManagerCommand request, CancellationToken cancellationToken)
            {
                var existing = uow.ProjectManagerRepository.GetByMobilePhone(request.ProjectManager!.MobilePhone!);
                if (existing != null) throw new ValidationException("Someone is already using the same mobile number.");
                await uow.ProjectManagerRepository.Create(mapper.Map<ProjectManager>(request.ProjectManager));
                await uow.Commit();
                return request.ProjectManager!;
            }
        }
    }
}
