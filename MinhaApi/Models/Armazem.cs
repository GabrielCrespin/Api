using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstoque.Models
{
    public class Armazem
    {
        [Key]
        public int UniqueId { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }

        
    }
}