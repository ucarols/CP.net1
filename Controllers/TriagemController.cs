using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Data;
using MotoPatioApi.Models;

namespace MotoPatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriagemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TriagemController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Triagem>>> GetAll() =>
            await _context.Triagens.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Triagem>> GetById(decimal id)
        {
            var item = await _context.Triagens.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Triagem item)
        {
            _context.Triagens.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(decimal id, Triagem item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(decimal id)
        {
            var item = await _context.Triagens.FindAsync(id);
            if (item == null) return NotFound();
            _context.Triagens.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
