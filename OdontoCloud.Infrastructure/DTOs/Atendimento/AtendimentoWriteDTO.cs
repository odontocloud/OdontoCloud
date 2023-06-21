using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Atendimento
{
    public class AtendimentoWriteDTO
    {
        [Required(ErrorMessage = "O IdCliente é obrigatório.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O IdFuncionário é obrigatório.")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "A Descrição do Atendimento é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Data do Atendimento é obrigatória.")]
        public DateTime Data { get; set; }

        public int TempoDuracao { get; set; }

        [Required(ErrorMessage = "O Valor do Atendimento é obrigatório.")]
        public double Valor { get; set; }

        public string Situacao { get; set; }
    }
}
