using DNC.ProjectAudit.Application.CQRS.Audits.OpenQuestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var question = await mediator.Send(new GetOpenQuestionByIdQuery { Id = id });
            if (question == null) return NotFound();
            return Ok(question);
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

        [HttpGet]
        [Route("{questionText}/ByQuestionText")]
        public async Task<IActionResult> GetQuestionByQuestionText(string questionText)
        {
            var question = await mediator.Send(new GetOpenQuestionByQuestionTextQuery { QuestionText = questionText});
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpGet]
        [Route("{questionnaireId}/{questionText}/OpenQuestionByQuestionnaireIdAndByQuestionText")]
        public async Task<IActionResult> GetByQuestionnaireIdAndQuestionByQuestionText(int questionnaireId, string questionText)
        {
            var question = await mediator.Send(new GetOpenQuestionByQuestionnaireIdAndByQuestionTextQuery { QuestionnaireId = questionnaireId, QuestionText = questionText });
            if (question == null) return NotFound();
            return Ok(question);
        }

    }
}
