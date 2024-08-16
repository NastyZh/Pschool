using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PschoolFrontEnd.Models;

namespace Pschool.Controllers
{  [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
  
    public class ParentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetParents()
        {
            var parents = await _context.Parents.ToListAsync();
            return Ok(parents); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
            var parent = await _context.Parents.Include(p => p.Children).FirstOrDefaultAsync(p => p.ParentId == id);
            if (parent == null)
            {
                return NotFound();
            }

            return Ok(parent); 
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Parent>> PostParent(Parent parent)
        {
            foreach (var child in parent.Children)
            {
                child.ParentId = parent.ParentId;
            }

            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
    
            return CreatedAtAction(nameof(GetParent), new { id = parent.ParentId }, parent);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int id, Parent parent)
        {
            if (id != parent.ParentId)
            {
                return BadRequest();
            }

            _context.Entry(parent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parents.Include(p => p.Children).FirstOrDefaultAsync(p => p.ParentId == id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
