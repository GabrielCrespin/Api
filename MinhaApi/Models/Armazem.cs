using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Models
{
    public class Armazem
    {
        [Key]
        public int UniqueId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ProdutoXArmazem> ProdutosXArmazens { get; set; }
    }
}