using System.Runtime.CompilerServices;

namespace OdontoCloud.Domain.Entities
{
    public enum TipoEndereco { Residencial, Comercial };

    public class Endereco
    {

        public Endereco() { }
        public Endereco(int id, int idCliente, string descricaoEndereco, string numero, string bairo, string cidade, string uF, string pais, string cep, string complemento, string tipo)
        {
            Id = id;
            IdCliente = idCliente;
            DescricaoEndereco = descricaoEndereco;
            Numero = numero;
            Bairo = bairo;
            Cidade = cidade;
            UF = uF;
            Pais = pais;
            Cep = cep;
            Complemento = complemento;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string DescricaoEndereco { get; set; }
        public string Numero { get; set; }
        public string Bairo { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string? Complemento { get; set; }
        public string Tipo { get; set; }
    }
}
