namespace GerenciamentoEstoque.Dto
{
    public class ProdutoXArmazemResponseDTO
    {
        public int IdProduto { get; set; }
        public int ArmazemUniqueId { get; set; }
        public string? CodigoArmazem { get; set; }
        public int Saldo { get; set; }
    }
}
