using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Infrastructure.DTOs.Anamnese
{
    public class AnamneseWriteDTO
    {
        [Required(ErrorMessage = "O Id do Cliente é obrigatório.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "A informação de Doença Cardiovascular é obrigatória.")]
        public bool DoencaCardiovascular { get; set; }
        public string? DescricaoDoencaCardiovascular { get; set; }

        [Required(ErrorMessage = "A informação de Hipertenção é obrigatória.")]
        public bool Hipertencao { get; set; }

        [Required(ErrorMessage = "A informação de Diabetes é obrigatória.")]
        public bool Diabetes { get; set; }

        [Required(ErrorMessage = "A informação de Doença Respiratória é obrigatória.")]
        public bool DoencaRespiratoria { get; set; }

        [Required(ErrorMessage = "A informação de Doença Hepática é obrigatória.")]
        public bool DoencaHepatica { get; set; }

        [Required(ErrorMessage = "A informação de Osteoporose é obrigatória.")]
        public bool Osteoporose { get; set; }

        [Required(ErrorMessage = "A informação de Coagulação do Sangramento é obrigatória.")]
        public bool CoagulacaoSangramento { get; set; }

        [Required(ErrorMessage = "A informação de Problema Gástrico é obrigatória.")]
        public bool ProblemaGastrico { get; set; }

        [Required(ErrorMessage = "A informação de Hepatite é obrigatória.")]
        public bool Hepatite { get; set; }

        [Required(ErrorMessage = "A informação de Tratamento Médico é obrigatória.")]
        public bool TratamentoMedico { get; set; }
        public string? DescricaoTratamentoMedico { get; set; }

        [Required(ErrorMessage = "A informação de Alergia é obrigatória.")]
        public bool Alergia { get; set; }
        public string? DescricaoAlergia { get; set; }

        [Required(ErrorMessage = "A informação de Fumante é obrigatória.")]
        public bool Fumante { get; set; }

        [Required(ErrorMessage = "A informação de Gravidez é obrigatória.")]
        public bool Gravida { get; set; }

        [Required(ErrorMessage = "A informação de Gravidez em Amamentação é obrigatória.")]
        public bool GravidaAmamentando { get; set; }

        [Required(ErrorMessage = "A informação de Restrição à Medicamento é obrigatória.")]
        public bool RestricaoMedicamento { get; set; }
        public string? DescricaoRestricaoMedicamento { get; set; }

        [Required(ErrorMessage = "A informação de Medicamento em Uso é obrigatória.")]
        public bool MedicamentoUso { get; set; }

        [Required(ErrorMessage = "A informação de Problema com Anestesia é obrigatória.")]
        public bool ProblemaAnestesia { get; set; }
    }
}
