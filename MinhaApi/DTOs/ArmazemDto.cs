using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Dto
{
    public class ArmazemDto
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
