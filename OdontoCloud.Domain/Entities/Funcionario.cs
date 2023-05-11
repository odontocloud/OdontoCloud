namespace OdontoCloud.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public string? TelCelular { get; set; }
        public string? TelResidencial { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
    }
}
