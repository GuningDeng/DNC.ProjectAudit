using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{
    public class SelectListQuestionsController : APIv1Controller
    {
        private readonly IMediator mediator;

        public SelectListQuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(await mediator.Send(new GetAllSelectListsQuery()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetQuestions(int id)
        {
            return Ok(await mediator.Send(new GetSelectListByIdQuery { Id = id}));
        }
    }
}
