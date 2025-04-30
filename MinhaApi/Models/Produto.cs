using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Grupo { get; set; }

        public ICollection<ProdutoXArmazem> ProdutosXArmazens { get; set; }
    }
}