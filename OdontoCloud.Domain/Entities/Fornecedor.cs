using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Domain.Entities
{
    public class Fornecedor
    {
        public Fornecedor() { }

        public Fornecedor(int id, string nomeFantasia, string razaoSocial, string cnpj, string endereco, string telResidencial, string telCelular, string complemento, int cep, string pais, string cidade, string bairro, int numero, string uf)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Endereco = endereco;
            TelResidencial = telResidencial;
            TelCelular = telCelular;
            Complemento = complemento;
            Cep = cep;
            Pais = pais;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            Uf = uf;
        }

        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? Endereco { get; set; }
        public string? TelResidencial { get; set; }
        public string? TelCelular { get; set; }
        public string? Complemento { get; set; }
        public int? Cep { get; set; }
        public string? Pais { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public string? Uf { get; set; }
    }
}
