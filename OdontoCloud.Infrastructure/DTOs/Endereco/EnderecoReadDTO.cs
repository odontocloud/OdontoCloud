﻿namespace OdontoCloud.Infrastructure.DTOs.Endereco
{
    public class EnderecoReadDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string DescricaoEndereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string? Complemento { get; set; }
        public string Tipo { get; set; }
    }
}
