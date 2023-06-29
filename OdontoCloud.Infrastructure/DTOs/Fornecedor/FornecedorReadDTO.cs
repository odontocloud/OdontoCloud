namespace OdontoCloud.Infrastructure.DTOs.Fornecedor
{
    public class FornecedorReadDTO
    {
        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? Endereco { get; set; }
        public string? TelResidencial { get; set; }
        public string? TelCelular { get; set; }
        public string? Complemento { get; set; }
        public int? Cep { get; set; }
        public string? Pais { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public string? Uf { get; set; }
    }
}
