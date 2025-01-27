using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{
    public class OpenQuestionsController : APIv1Controller
    {
        private readonly IMediator mediator;

        public OpenQuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(await mediator.Send(new GetOpenQuestionsQuery()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            return Ok(await mediator.Send(new GetAllOpenQuestionByIdQuery { Id = id }));
        }

    }
}
