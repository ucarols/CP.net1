using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Data;
using MotoPatioApi.Models;

namespace MotoPatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PatioController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll() =>
            await _context.Patios.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetById(decimal id)
        {
            var item = await _context.Patios.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Patio item)
        {
            _context.Patios.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(decimal id, Patio item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(decimal id)
        {
            var item = await _context.Patios.FindAsync(id);
            if (item == null) return NotFound();
            _context.Patios.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
