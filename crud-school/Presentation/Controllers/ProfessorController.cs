using Application.Professor.Commands.Create;
using Application.Professor.Commands.Update;
using Application.Student.Commands.Update;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("professors")]
    public class ProfessorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;   

        public ProfessorController(AppDbContext dbContext, IMediator mediator)
        {
            _context = dbContext;
            _mediator = mediator;   
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> List()
        {
            return _context.Professor.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> Get(int id)
        {
            var professor = _context.Professor.Find(id);
            if (professor == null)
            {
                return NotFound();
            }
            return professor;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfessorCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateProfessorCommand command)
        {
            var resultId = await _mediator.Send(command);
            return resultId > 0 ? Ok(resultId) : NotFound();
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var professor = _context.Professor.Find(Id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professor.Remove(professor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
