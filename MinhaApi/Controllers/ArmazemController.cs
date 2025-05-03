using GerenciamentoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoEstoque.Data;
using GerenciamentoEstoque.Dto;

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
            if (armazem == null)
            {
                return NotFound();
            }
            return armazem;
        }

        [HttpPost]
        public async Task<ActionResult<Armazem>> Post(ArmazemDto armazemDTO)
        {
            var armazem = new Armazem
            {
                Codigo = armazemDTO.Codigo,
                Descricao = armazemDTO.Descricao
            };

            _context.Armazens.Add(armazem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { UniqueId = armazem.UniqueId }, armazem);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ArmazemDto armazemDTO)
        {
            var armazem = await _context.Armazens.FindAsync(id);

            if (armazem == null)
            {
                return NotFound("Armazém não encontrado");
            }

            armazem.Codigo = armazemDTO.Codigo;
            armazem.Descricao = armazemDTO.Descricao;

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
                return NotFound("ID não encontrado");
            }
            _context.Armazens.Remove(armazem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}