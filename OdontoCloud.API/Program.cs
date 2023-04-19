using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.Repositories;
using System.Runtime.InteropServices;

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

        //var optionsBuilder = new DbContextOptionsBuilder<OdontoCloudDBContext>();
        //var context = new OdontoCloudDBContext(optionsBuilder.Options);

        //var repository = new ClienteRepository(context);
        //repository.Save(cliente);

        app.Run();
    }
}