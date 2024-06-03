using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Application.Student.Queries.List;
using Application.Student.Queries.Get;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Application.Student.Commands.Create;
using Application.Student.Commands.Update;
using Application.Student.Commands.Delete;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {

        private readonly IMediator _mediator;


        public StudentController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _mediator.Send(new GetListStudentQuery());
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetStudentQuery query)
        {
            var student = await _mediator.Send(query);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var resultId = await _mediator.Send(command);
            return resultId > 0 ? Ok(resultId) : NotFound();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] DeleteStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
