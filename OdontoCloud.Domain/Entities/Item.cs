using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Domain.Entities
{
    public class Item
    {
        public Item() { }
        public Item(int id, int idFornecedor, string descricao, double quantidadeEstoque, string unidadeMedida, double valorUnitario, string marca)
        {
            Id = id;
            IdFornecedor = idFornecedor;
            Descricao = descricao;
            QuantidadeEstoque = quantidadeEstoque;
            UnidadeMedida = unidadeMedida;
            ValorUnitario = valorUnitario;
            Marca = marca;
        }

        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public string Descricao { get; set; }
        public double QuantidadeEstoque { get; set; }
        public string UnidadeMedida { get; set; }
        public double ValorUnitario { get; set; }
        public string Marca { get; set; }
        public List<DetalheAtendimento> DetalheAtendimentos { get; set; }
    }
}
