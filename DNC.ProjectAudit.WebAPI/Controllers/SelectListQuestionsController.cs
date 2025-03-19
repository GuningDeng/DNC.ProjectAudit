using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using DNC.ProjectAudit.Application.CQRS.Audits.SelectListQuestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await mediator.Send(new GetSelectListByIdQuery { Id = id });
            if (question == null) return NotFound();
            return Ok(question);
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

        [HttpGet]
        [Route("{questionText}/ByQuestionText")]
        public async Task<IActionResult> GetQuestionByQuestionText(string questionText)
        {
            var question = await mediator.Send(new GetSelectListByQuestionTextQuery { QuestionText = questionText });
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpGet]
        [Route("{questionnaireId}/{questionText}/OpenQuestionByQuestionnaireIdAndByQuestionText")]
        public async Task<IActionResult> GetByQuestionnaireIdAndQuestionByQuestionText(int questionnaireId, string questionText)
        {
            var question = await mediator.Send(new GetSelectlistQuestionByQuestionnaireIdAndByQuestionTextQuery { QuestionnaireId = questionnaireId, QuestionText = questionText });
            if (question == null) return NotFound();
            return Ok(question);
        }

    }
}
