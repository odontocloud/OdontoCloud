using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Fornecedor
{
    public class FornecedorWriteDTO
    {
        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        public string? Cnpj { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public string? Endereco { get; set; }

        public string? TelResidencial { get; set; }
        public string? TelCelular { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public int? Cep { get; set; }

        [Required(ErrorMessage = "O País é obrigatório.")]
        public string? Pais { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        public int? Numero { get; set; }

        [Required(ErrorMessage = "A UF é obrigatória.")]
        public string? Uf { get; set; }
    }
}
