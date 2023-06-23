using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.DetalheAtendimento
{
    public class DetalheAtendimentoWriteDTO
    {
        [Required(ErrorMessage = "O Id do Atendimento é obrigatório.")]
        public int IdAtendimento { get; set; }

        [Required(ErrorMessage = "O Id do Item é obrigatório.")]
        public int IdItem { get; set; }

        [Required(ErrorMessage = "A Quantidade de Item é obrigatória.")]
        public float QuantidadeItem { get; set; }
    }
}
