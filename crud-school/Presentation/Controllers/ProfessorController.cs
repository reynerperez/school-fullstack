using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("professors")]
    public class ProfessorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessorController(AppDbContext dbContext)
        {
            _context = dbContext;
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
        public ActionResult<Professor> Create([FromBody] Professor professor)
        {
            _context.Professor.Add(professor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), professor.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Professor toUpdateProfessor)
        {
            var professor = _context.Professor.Find(id);
            if (professor == null)
            {
                return NotFound();
            }
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professor.Find(id);
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
