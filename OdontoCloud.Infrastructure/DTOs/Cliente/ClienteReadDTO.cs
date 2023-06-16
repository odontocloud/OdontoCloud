using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Infrastructure.DTOs.Cliente
{
    public class ClienteReadDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? EstadoCivil { get; set; }

        public string? TelCelular { get; set; }

        public string? TelResidencial { get; set; }

        public string? IndicadoPor { get; set; }

        public string? DNLE { get; set; }

        public string? Profissao { get; set; }
    }
}
