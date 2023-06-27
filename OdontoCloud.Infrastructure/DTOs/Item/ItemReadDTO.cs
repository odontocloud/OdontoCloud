namespace OdontoCloud.Infrastructure.DTOs.Item
{
    public class ItemReadDTO
    {
        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public string Descricao { get; set; }
        public double QuantidadeEstoque { get; set; }
        public string UnidadeMedida { get; set; }
        public double ValorUnitario { get; set; }
        public string Marca { get; set; }
    }
}
