using GerenciamentoEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoque.Data;

namespace GerenciamentoEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoXArmazemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoXArmazemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{armazemId}")]
        public async Task<ActionResult> GetProdutoXArmazens(int armazemId)
        {
            var produtoXArmazem = await _context.ProdutoXArmazens
            .Where(pxa => pxa.IdArmazem == armazemId)
            .Include(pxa => pxa.Produto)
            .ToListAsync();

            if(produtoXArmazem == null || produtoXArmazem.Count == 0)
            {
                return NotFound("Nenhum produto encontrado para este armazem.");
            }
            return Ok(produtoXArmazem);
        }

        [HttpPost]
        public async Task<ActionResult> PostProdutoXArmazem(ProdutoXArmazem produtoXArmazem)
        {
            var armazem = await _context.Armazens.FindAsync(produtoXArmazem.IdArmazem);
            if (armazem == null)
            {
                return NotFound("Armazem nao encontrado.");
            }
            _context.ProdutoXArmazens.Add(produtoXArmazem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutoXArmazens), new {armazemId = produtoXArmazem.IdArmazem}, produtoXArmazem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProdutoXArmazem(int id)
        {
            var produtoXArmazem = await _context.ProdutoXArmazens.FindAsync(id);
            if(produtoXArmazem == null)
            {
                return NotFound("Produto no armazem nao encontrado.");
            }
            _context.ProdutoXArmazens.Remove(produtoXArmazem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}