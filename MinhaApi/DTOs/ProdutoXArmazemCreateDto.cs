using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Dto
{
    public class ProdutoXArmazemCreateDto
    {
        [Required]
        public int IdProduto { get; set; }

        [Required]
        public int ArmazemUniqueId { get; set; }

        [Required]
        public int Saldo { get; set; }
    }
}
