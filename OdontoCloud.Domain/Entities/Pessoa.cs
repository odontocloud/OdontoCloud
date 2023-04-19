namespace OdontoCloud.Domain.Entities
{
    public enum EstadoCivilEnum { Solteiro, Casado, Divorciado, Separado, Viúvo };

    public abstract class Pessoa
    {
        protected Pessoa() { }
        protected Pessoa(int id, string nome, string cPF, string rG, DateTime dataNascimento, string? estadoCivil, string? profissao)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            RG = rG;
            DataNascimento = dataNascimento;
            EstadoCivil = estadoCivil;
            Profissao = profissao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Profissao { get; set; }
    }
}