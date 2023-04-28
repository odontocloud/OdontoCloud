namespace OdontoCloud.Domain.Entities
{
    public class Atendimento
    {
        public Atendimento() { }
        public Atendimento(int id, int idCliente, DateTime data, int tempoDuracao, double valor, string descricao, string situacao)
        {
            Id = id;
            IdCliente = idCliente;
            Data = data;
            TempoDuracao = tempoDuracao;
            Valor = valor;
            Descricao = descricao;
            Situacao = situacao;
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int TempoDuracao { get; set; }
        public double Valor { get; set; }
        public string Situacao { get; set; } //qual será a situação? Será um enum?
    }
}
