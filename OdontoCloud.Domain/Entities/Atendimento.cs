﻿namespace OdontoCloud.Domain.Entities
{
    public class Atendimento
    {
        public Atendimento() { }
        public Atendimento(int id, int idCliente, int idFuncionario, DateTime data, int tempoDuracao, double valor, string descricao, string situacao)
        {
            Id = id;
            IdCliente = idCliente;
            IdFuncionario = idFuncionario;
            Data = data;
            TempoDuracao = tempoDuracao;
            Valor = valor;
            Descricao = descricao;
            Situacao = situacao;
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario{ get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int TempoDuracao { get; set; }
        public double Valor { get; set; }
        public string Situacao { get; set; } //qual será a situação? Será um enum?}
        public List<DetalheAtendimento> DetalhesAtendimento { get; set; }
    }
}
