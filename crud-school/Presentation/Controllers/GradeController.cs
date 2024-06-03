using Application.Grade.Queries.Get;
using Application.Grade.Queries.List;
using Application.Grade.Commands.Create;
using Application.Grade.Commands.Delete;
using Application.Grade.Commands.Update;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("grades")]
    public class GradeController : ControllerBase
    {
        private readonly IMediator _mediator;


        public GradeController( IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var grades = await _mediator.Send(new GetListGradeQuery());
            return Ok(grades);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetGradeQuery query)
        {
            var grade = await _mediator.Send(query);
            return Ok(grade);
        }

        [HttpPost]
        public async Task<IActionResult> Creategrade([FromBody] CreateGradeCommand command)
        {
            var id = await _mediator.Send(command);
            return id > 0 ? Created() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updategrade(int id, [FromBody] UpdateGradeCommand command)
        {
            command.Id = id;
            var resultId = await _mediator.Send(command);
            return resultId > 0 ? Ok(resultId) : NotFound();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Deletegrade([FromRoute] DeleteGradeCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
