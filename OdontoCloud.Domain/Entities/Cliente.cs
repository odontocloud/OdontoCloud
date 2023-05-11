namespace OdontoCloud.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Cliente() { }  
        public string? TelCelular { get; set; }
        public string? TelResidencial { get; set; }
        public string? IndicadoPor { get; set; }
        public string? DNLE { get; set; }
        public string? Profissao { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
        public List<Anamnese> Anamneses { get; set; }
    }
}
