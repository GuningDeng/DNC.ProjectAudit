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

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] SelectListQuestionDTO newQuestion)
        {
            return Ok(await mediator.Send(new AddSelectListQuestionCommand { SelectListQuestion = newQuestion}));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] SelectListQuestionDTO updateQuestion)
        {
            if (updateQuestion.Id != id) return BadRequest();
            return Ok(await mediator.Send(new UpdateSelectListQuestionCommand { SelectListQuestion = updateQuestion}));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await mediator.Send(new DeleteSelectListQuestionCommand { Id = id });
            return NoContent();
        }
    }
}
