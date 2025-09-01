using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Data;
using MotoPatioApi.Models;

namespace MotoPatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoramentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MonitoramentoController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monitoramento>>> GetAll() =>
            await _context.Monitoramentos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Monitoramento>> GetById(decimal id)
        {
            var item = await _context.Monitoramentos.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Monitoramento item)
        {
            _context.Monitoramentos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(decimal id, Monitoramento item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(decimal id)
        {
            var item = await _context.Monitoramentos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Monitoramentos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
