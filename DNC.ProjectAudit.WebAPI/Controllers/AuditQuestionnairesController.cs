using DNC.ProjectAudit.Application.CQRS.Audits;
using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using DNC.ProjectAudit.Application.Exceptions;
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
        [Route("{id}")]
        public async Task<IActionResult> GetAuditQuestionnaireById(int id) 
        {
            var qeustionnaire = await _mediator.Send(new GetAuditQuestionnaireByIdQuery { Id = id });
            if (qeustionnaire == null) return NotFound();
            return Ok(qeustionnaire);
        }

        [HttpGet]
        [Route("{id}/Quick")]
        public async Task<IActionResult> GetAuditQuestionnaireByIdQuick(int id)
        {
            return Ok(await _mediator.Send(new GetAuditQuestionnaireByIdQuickQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuditQuestionnaire([FromBody] AuditQuestionnaireDetailDTO auditQuestionnaire)
        {
            try
            {
                return Created("", await _mediator.Send(new AddAuditQuestionnaireCommand { AuditQuestionnaire = auditQuestionnaire }));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAuditQuestionnaire(int id, [FromBody] AuditQuestionnaireDetailDTO updatedAuditQuestionnaire)
        {
            if (updatedAuditQuestionnaire.Id != id) return BadRequest();
            return Ok(await _mediator.Send(new UpdateAuditQuestionnaireCommand { AuditQuestionnaire = updatedAuditQuestionnaire}));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAuditQuestionnaire(int id)
        {
            await _mediator.Send(new DeleteAuditQuestionnaireCommand { Id = id});
            return NoContent();
        }

        [HttpGet]
        [Route("{name}/ByName")]
        public async Task<IActionResult> GetAuditQuestionnaireByName(string name)
        {
            var questionnaire = await _mediator.Send(new GetAuditQuestionnaireByNameQuery { Name = name });
            if (questionnaire == null) return NotFound();
            return Ok(questionnaire); 
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/MultipleChoiceQuestions")]
        public async Task<IActionResult> GetMultipleChoiceQuestionsByAuditQuestionnaireId(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetMultipleChoiceQuestionsByAudtiQuestionnaireIdQuery { Id = auditQuestionnaireId }));
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/MultipleChoiceQuestionsByIsDisplayPriority")]
        public async Task<IActionResult> GetMultipleChoiceQuestionsByAuditQuestionnaireIdByIsDisplayPriority(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetMultipleChoiceQuestionsByAudtiQuestionnaireIdByIsDisplayPriorityIndicationQuery { Id = auditQuestionnaireId }));
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/OpenQuestionsByAuditQuestionnaireId")]
        public async Task<IActionResult> GetOpenQuestionsByAuditQuestionnaireId(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetOpenQuestionsByAudtiQuestionnaireIdQuery { Id=auditQuestionnaireId }));
        }

        [HttpGet]
        [Route("{auditQuestionnaireId}/SelectListQuestionsByAuditQuestionnaireId")]
        public async Task<IActionResult> GetSelectListQuestionsByAuditQuestionnaireId(int auditQuestionnaireId)
        {
            return Ok(await _mediator.Send(new GetSelectListQuestionsByAudtiQuestionnaireIdQuery { Id = auditQuestionnaireId }));
        }

    }
}
