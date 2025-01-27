using DNC.ProjectAudit.Application.CQRS.People;
using DNC.ProjectAudit.Application.CQRS.People.Auditors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{
    public class AuditorsController : APIv1Controller
    {
        private readonly IMediator _mediator;

        public AuditorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Auditor")]
        public async Task<IActionResult> GetAuditor()
        {
            return Ok(await _mediator.Send(new GetAuditorQuery()));
        }
    }
}
