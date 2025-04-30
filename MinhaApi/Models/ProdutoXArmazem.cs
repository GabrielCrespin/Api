using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Models
{
    public class ProdutoXArmazem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        [Required]
        public int ArmazemUniqueId { get; set; }
        public Armazem Armazem { get; set; }
        [Required]
        public int Saldo { get; set; }
    }
}