using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.Repositories;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        //Cliente cliente = new Cliente();
        //cliente.CPF = "425945";
        //cliente.Nome = "Eduardo";
        //cliente.RG = "14646544";
        //cliente.EstadoCivil = EstadoCivilEnum.Casado.ToString();
        //cliente.DataNascimento = new DateTime(1995, 12, 08);
        //cliente.Profissao = "Gogoboy";
        //cliente.DNLE = "";
        //cliente.TelCelular = "1899754565";

        //Endereco endereco = new Endereco();
        //endereco.DescricaoEndereco = "Rua do Fico";
        //endereco.Numero = "134B";
        //endereco.Bairo = "Ipanema";
        //endereco.Cidade = "Araçatuba";
        //endereco.UF = "SP";
        //endereco.Pais = "Brasil";
        //endereco.Cep = "16052-250";
        //endereco.Complemento = "Nada";
        //endereco.Tipo = TipoEndereco.Residencial.ToString();

        Atendimento atendimento = new Atendimento();
        atendimento.Descricao = "Limpeza";
        atendimento.Data = new DateTime(2023, 04, 28);
        atendimento.IdCliente = 1;
        atendimento.Situacao = "Finalizado";
        atendimento.TempoDuracao = 60;
        atendimento.Valor = 100;

        var optionsBuilder = new DbContextOptionsBuilder<OdontoCloudDBContext>();
        var context = new OdontoCloudDBContext(optionsBuilder.Options);

        var repository = new AtendimentoRepository(context);
        repository.Save(atendimento);

        app.Run();
    }
}