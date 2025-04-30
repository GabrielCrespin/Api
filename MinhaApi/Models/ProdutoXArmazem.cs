namespace GerenciamentoEstoque.Models
{
    public class ProdutoXArmazem
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int ArmazemUniqueId { get; set; }
        public Armazem Armazem { get; set; }
        public int Saldo { get; set; }
    }
}