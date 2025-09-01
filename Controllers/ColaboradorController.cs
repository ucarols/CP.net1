using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Data;
using MotoPatioApi.Models;

namespace MotoPatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ColaboradorController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetAll() =>
            await _context.Colaboradores.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetById(decimal id)
        {
            var item = await _context.Colaboradores.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Colaborador item)
        {
            _context.Colaboradores.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(decimal id, Colaborador item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(decimal id)
        {
            var item = await _context.Colaboradores.FindAsync(id);
            if (item == null) return NotFound();
            _context.Colaboradores.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
