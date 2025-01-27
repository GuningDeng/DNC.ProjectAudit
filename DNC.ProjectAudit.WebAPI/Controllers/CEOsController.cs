using DNC.ProjectAudit.Application.CQRS.People;
using DNC.ProjectAudit.Application.CQRS.People.CEOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{    
    public class CEOsController : APIv1Controller
    {
        private readonly IMediator _mediator;

        public CEOsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("CEO")]
        public async Task<IActionResult> GetCEO()
        {
            return Ok(await _mediator.Send(new GetCEOQuery()));
        }

    }
}
