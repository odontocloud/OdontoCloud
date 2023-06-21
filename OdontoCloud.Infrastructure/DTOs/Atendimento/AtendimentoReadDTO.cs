using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Infrastructure.DTOs.Atendimento
{
    public class AtendimentoReadDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int TempoDuracao { get; set; }
        public double Valor { get; set; }
        public string Situacao { get; set; }
    }
}
