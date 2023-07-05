namespace OdontoCloud.Infrastructure.DTOs.Anamnese
{
    public class AnamneseReadDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public bool DoencaCardiovascular { get; set; }
        public string? DescricaoDoencaCardiovascular { get; set; }
        public bool Hipertencao { get; set; }
        public bool Diabetes { get; set; }
        public bool DoencaRespiratoria { get; set; }
        public bool DoencaHepatica { get; set; }
        public bool Osteoporose { get; set; }
        public bool CoagulacaoSangramento { get; set; }
        public bool ProblemaGastrico { get; set; }
        public bool Hepatite { get; set; }
        public bool TratamentoMedico { get; set; }
        public string? DescricaoTratamentoMedico { get; set; }
        public bool Alergia { get; set; }
        public string? DescricaoAlergia { get; set; }
        public bool Fumante { get; set; }
        public bool Gravida { get; set; }
        public bool GravidaAmamentando { get; set; }
        public bool RestricaoMedicamento { get; set; }
        public string? DescricaoRestricaoMedicamento { get; set; }
        public bool MedicamentoUso { get; set; }
        public bool ProblemaAnestesia { get; set; }
    }
}
