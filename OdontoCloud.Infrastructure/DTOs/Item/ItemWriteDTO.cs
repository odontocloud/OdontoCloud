using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Item
{
    public class ItemWriteDTO
    {
        [Required(ErrorMessage = "O Id do Fornecedor é obrigatório.")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "A Descrição do Item é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        public double QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "A Unidade de Medida é obrigatória.")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "O Valor Unitário é obrigatório.")]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória.")]
        public string Marca { get; set; }
    }
}
