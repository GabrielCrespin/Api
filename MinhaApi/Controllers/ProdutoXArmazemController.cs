using GerenciamentoEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoque.Data;
using GerenciamentoEstoque.Dto;

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
            .Where(pxa => pxa.ArmazemUniqueId == armazemId)
            .Include(pxa => pxa.Produto)
            .Include(pxa => pxa.Armazem)
            .ToListAsync();

            if (produtoXArmazem == null || produtoXArmazem.Count == 0)
            {
                return NotFound("Nenhum produto encontrado para este armazem.");
            }
            var resultado = produtoXArmazem.Select(pxa => new
            {
                pxa.Id,
                ProdutoId = pxa.IdProduto,
                ProdutoCodigo = pxa.Produto?.Codigo,
                ProdutoDescricao = pxa.Produto?.Descricao,
                ArmazemId = pxa.ArmazemUniqueId,
                ArmazemCodigo = pxa.Armazem?.Codigo,
                ArmazemDescricao = pxa.Armazem?.Descricao,
                Saldo = pxa.Saldo
            });
            return Ok(resultado);
        }

        [HttpGet("saldo-produto")]
        public async Task<ActionResult> GetSaldosDoProduto([FromQuery] int idProduto, [FromQuery] int ArmazemUniqueId)
        {
            var registro = await _context.ProdutoXArmazens
                .Where(pxa => pxa.IdProduto == idProduto && pxa.ArmazemUniqueId == ArmazemUniqueId)
                .Include(pxa => pxa.Armazem)
                .FirstOrDefaultAsync();

            if (registro == null)
            {
                return NotFound("Este produto não está presente neste armazém");
            }

            var resultado = new ProdutoXArmazemResponseDTO
            {
                IdProduto = registro.IdProduto,
                ArmazemUniqueId = registro.ArmazemUniqueId,
                CodigoArmazem = registro.Armazem?.Codigo,
                Saldo = registro.Saldo
            };

            return Ok(resultado);
        }


        [HttpPost]
        public async Task<ActionResult> PostProdutoXArmazem(ProdutoXArmazemCreateDto dto)
        {
            var armazem = await _context.Armazens.FindAsync(dto.ArmazemUniqueId);
            if (armazem == null)
            {
                return NotFound("Armazém não encontrado.");
            }

            var produto = await _context.Produtos.FindAsync(dto.IdProduto);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            var produtoXArmazem = new ProdutoXArmazem
            {
                IdProduto = dto.IdProduto,
                ArmazemUniqueId = dto.ArmazemUniqueId,
                Saldo = dto.Saldo
            };

            _context.ProdutoXArmazens.Add(produtoXArmazem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSaldosDoProduto), new { idProduto = dto.IdProduto, ArmazemUniqueId = dto.ArmazemUniqueId }, produtoXArmazem);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ProdutoXArmazemUpdateDto produtoXArmazemUpdateDto)
        {
            var produtoXArmazem = await _context.ProdutoXArmazens
            .FirstOrDefaultAsync(pxa => pxa.IdProduto == produtoXArmazemUpdateDto.IdProduto && pxa.ArmazemUniqueId == produtoXArmazemUpdateDto.ArmazemUniqueId);
            
            if (produtoXArmazem == null)
            {
                return NotFound("Produto ou Armazem não encontrado");
            }

            produtoXArmazem.Saldo = produtoXArmazemUpdateDto.Saldo;
            _context.Entry(produtoXArmazem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProdutoXArmazem(int id)
        {
            var produtoXArmazem = await _context.ProdutoXArmazens.FindAsync(id);
            if (produtoXArmazem == null)
            {
                return NotFound("Produto no armazem nao encontrado.");
            }
            _context.ProdutoXArmazens.Remove(produtoXArmazem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}