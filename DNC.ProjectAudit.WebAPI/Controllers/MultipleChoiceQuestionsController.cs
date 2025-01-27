using DNC.ProjectAudit.Application.CQRS.Audits.MultipleChoiceQuestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DNC.ProjectAudit.WebAPI.Controllers
{
    public class MultipleChoiceQuestionsController : APIv1Controller
    {
        private readonly IMediator mediator;

        public MultipleChoiceQuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMultipleChoiceQuestion()
        {
            return Ok(await mediator.Send(new GetAllMultipleChoiceQuestionsQuery()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            return Ok(await mediator.Send(new GetMultipleChoiceQuestionByIdQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMultipleChoice([FromBody] MultipleChoiceQuestionDTO multipleChoice)
        {
            return Created("", await mediator.Send(new AddMultipleChoiceQuestionCommand { MultipleChoiceQuestion = multipleChoice }));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatedQuestion(int id, [FromBody] MultipleChoiceQuestionDTO updatedQuestion)
        {
            if (id != updatedQuestion.Id) return BadRequest();

            return Ok(await mediator.Send(new UpdateMultipleChoiceQuestionByIdCommand { MultipleChoiceQuestion = updatedQuestion}));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await mediator.Send(new DeleteMultipleChoiceQuestionByIdCommand { Id = id });
            return NoContent();
        }

    }
}
