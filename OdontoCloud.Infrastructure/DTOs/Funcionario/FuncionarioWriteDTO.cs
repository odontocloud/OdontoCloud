using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Funcionario
{
    public class FuncionarioWriteDTO
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

        [Required(ErrorMessage = "O Cargo é obrigatório.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O Salário é obrigatório.")]
        public double Salario { get; set; }
    }
}
