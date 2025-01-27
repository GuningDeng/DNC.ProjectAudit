using AutoMapper;
using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using DNC.ProjectAudit.Application.CQRS.People.Auditors;
using DNC.ProjectAudit.Application.CQRS.People.CEOs;
using DNC.ProjectAudit.Application.CQRS.People.ProjectManagers;
using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions;
using DNC.ProjectAudit.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application
{
    internal class Mappings : Profile
    {
        public Mappings() 
        {
            CreateMap<CEO, CEODTO>();
            CreateMap<Auditor, AuditorDTO>();
            CreateMap<ProjectManager, ProjectManagerDTO>();
            CreateMap<ProjectManager, ProjectManagerDetailDTO>().ReverseMap();

            CreateMap<AuditQuestionnaire, AuditQuestionnaireDTO>();
            CreateMap<AuditQuestionnaire, AuditQuestionnaireDetailDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<OpenQuestion, OpenQuestionDTO>().ReverseMap();
            CreateMap<SelectListQuestion, SelectListQuestionDTO>().ReverseMap();

        }

    }
}
