using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Infrastructure.DTOs.Endereco
{
    public class EnderecoWriteDTO
    {
        //public int IdCliente { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public string DescricaoEndereco { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A Unidade Federativa é obrigatória.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O País é obrigatório.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string Cep { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Tipo (residencial ou comercial) é obrigatório.")]
        public string Tipo { get; set; }
    }
}
