namespace GerenciamentoEstoque.Models
{
    public class ProdutoXArmazem
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int IdArmazem { get; set; }
        public Armazem Armazem { get; set; }
        public int Saldo { get; set; }
    }
}