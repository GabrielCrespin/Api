using GerenciamentoEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoque.Data;
using GerenciamentoEstoque.Dto;

namespace GerenciamentoEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpGet("por-codigo/{codigo}")]
        public async Task<ActionResult<Produto>> GetProdutoPorCodigo(string codigo)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo.ToLower().Trim() == codigo.ToLower().Trim());
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutoDto produtoDTO)
        {
            var produto = new Produto
            {
                Codigo = produtoDTO.Codigo,
                Descricao = produtoDTO.Descricao,
                Grupo = produtoDTO.Grupo
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutos), new { Id = produto.Id }, produto);
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, ProdutoDto produtoDto)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound("ID da url nao bate com o ID do produto enviado");
            }

            produto.Codigo = produtoDto.Codigo;
            produto.Descricao = produtoDto.Descricao;
            produto.Grupo = produtoDto.Grupo;

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}