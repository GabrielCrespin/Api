namespace GerenciamentoEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Grupo { get; set; }

        public ICollection<ProdutoXArmazem> ProdutosXArmazens { get; set; }
    }
}