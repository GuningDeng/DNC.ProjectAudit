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
            return Ok(await mediator.Send(new GetAllOpenQuestionsQuery()));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            return Ok(await mediator.Send(new GetOpenQuestionByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] OpenQuestionDTO openQuestion)
        {
            return Ok(await mediator.Send(new AddOpenQuestionCommand { OpenQuestion = openQuestion }));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] OpenQuestionDTO updateOpenQuestion)
        {
            if (id != updateOpenQuestion.Id) return BadRequest();
            return Ok(await mediator.Send(new UpdateOpenQuestionByIdCommand { OpenQuestion = updateOpenQuestion }));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await mediator.Send(new DeleteOpenQuestionByIdCommand { Id = id });
            return NoContent();
        }

    }
}
