using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Dto
{
    public class ProdutoDto
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Grupo { get; set; }
    }
}