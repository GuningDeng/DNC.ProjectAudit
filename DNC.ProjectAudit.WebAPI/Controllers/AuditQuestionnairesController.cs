using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Infrastructure.Repositories.AuditRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{
    public class AuditQuestionnairesController : APIv1Controller
    {
        private readonly IMediator _mediator;

        public AuditQuestionnairesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuditQuestionnaires()
        {
            return Ok(await _mediator.Send(new GetAllAuditQuestionnairesQuery()));
        }

        [HttpGet]
        [Route("Quick")]
        public async Task<IActionResult> GetAllAuditQuestionnairesQuick()
        {
            return Ok(await _mediator.Send(new GetAllAuditQuestionnairesQuickQuery()));
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/MultipleChoiceQuestions")]
        public async Task<IActionResult> GetMultipleChoiceQuestionsByAuditQuestionnaireId(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQuery { Id = auditQuestionnaireId }));
        }

        [HttpGet]
        //[Route("{assignmentId}/MultipleChoices")]
        [Route("{auditQuestionnaireId}/MultipleChoiceQuestionsByIsDisplayPriority")]
        public async Task<IActionResult> GetMultipleChoiceQuestionsByAuditQuestionnaireIdByIsDisplayPriority(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplyPriorityIndicationQuery { Id = auditQuestionnaireId }));
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/OpenQuestionsByAuditQuestionnaireId")]
        public async Task<IActionResult> GetQuestionsByAuditQuestionnaireId(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetOpenQuestionsByAudtiQuestionnaireIdQuery { Id=auditQuestionnaireId }));
        }
    }
}
