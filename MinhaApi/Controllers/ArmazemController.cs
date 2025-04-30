using GerenciamentoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoEstoque.Data;

namespace GerenciamentoEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmazemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArmazemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Armazem>>> Get()
        {
            return await _context.Armazens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Armazem>> Get(int id)
        {
            var armazem = await _context.Armazens.FindAsync(id);
            if(armazem == null)
            {
                return NotFound();
            }
            return armazem;
        }

        [HttpPost]
        public async Task<ActionResult<Armazem>> Post(Armazem armazem)
        {
            _context.Add(armazem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new{UniqueiD = armazem.UniqueId}, armazem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Armazem armazem)
        {
            if (id != armazem.UniqueId)
            {
                return BadRequest("ID da url nao bate com o ID do produto enviado");
            }
            _context.Entry(armazem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var armazem = await _context.Armazens.FindAsync(id);
            if (armazem == null)
            {
                NotFound();
            }
            _context.Armazens.Remove(armazem);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}