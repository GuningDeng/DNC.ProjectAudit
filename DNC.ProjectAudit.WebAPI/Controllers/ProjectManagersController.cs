using DNC.ProjectAudit.Application.CQRS.People.ProjectManagers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{    
    public class ProjectManagersController : APIv1Controller
    {
        private readonly IMediator _mediator;

        public ProjectManagersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectManagers()
        {
            return Ok(await _mediator.Send(new GetAllProjectManagersQuery()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProjectManagerById(int id)
        {
            var manager = await _mediator.Send(new GetProjectManagerByIdQuery { Id = id });
            if (manager == null) return NotFound();
            return Ok(manager);
        }
    }
}
