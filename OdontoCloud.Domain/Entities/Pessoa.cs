using System.ComponentModel.DataAnnotations;

namespace OdontoCloud.Domain.Entities
{
    public enum EstadoCivilEnum { Solteiro, Casado, Divorciado, Separado, Viúvo };

    public abstract class Pessoa
    {
        protected Pessoa() { }
        protected Pessoa(int id, string nome, string cPF, string rG, DateTime dataNascimento, string? estadoCivil)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            RG = rG;
            DataNascimento = dataNascimento;
            EstadoCivil = estadoCivil;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório.")]
        public string RG { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        public string? EstadoCivil { get; set; }
    }
}