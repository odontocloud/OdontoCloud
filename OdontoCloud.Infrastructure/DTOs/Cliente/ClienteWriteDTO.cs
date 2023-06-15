using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Cliente
{
    public class ClienteWriteDTO
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório.")]
        public string RG { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        public string? EstadoCivil { get; set; }

        public string? TelCelular { get; set; }

        public string? TelResidencial { get; set; }

        public string? IndicadoPor { get; set; }

        public string? DNLE { get; set; }

        public string? Profissao { get; set; }
    }
}
