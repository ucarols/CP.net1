using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Data;
using MotoPatioApi.Models;

namespace MotoPatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MotoController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll() =>
            await _context.Motos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(decimal id)
        {
            var item = await _context.Motos.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Moto item)
        {
            _context.Motos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(decimal id, Moto item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(decimal id)
        {
            var item = await _context.Motos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Motos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
