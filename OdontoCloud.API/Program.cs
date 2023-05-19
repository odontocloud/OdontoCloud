using Microsoft.EntityFrameworkCore;
using OdontoCloud.Infrastructure.Context;

internal class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddDbContext<OdontoCloudDBContext>(options =>
        //    options.UseSqlServer("DefaultConnection"));

        //builder.Services.AddScoped<IRepository, ClienteRepository>();

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

        //Atendimento atendimento = new Atendimento();
        //atendimento.Descricao = "Limpeza";
        //atendimento.Data = new DateTime(2023, 04, 28);
        //atendimento.IdCliente = 3;
        //atendimento.Situacao = "Finalizado";
        //atendimento.TempoDuracao = 60;
        //atendimento.Valor = 100;

        //DetalheAtendimento detalheAtendimento = new DetalheAtendimento();
        //detalheAtendimento.IdAtendimento = 1;
        //detalheAtendimento.IdItem = 1;
        //detalheAtendimento.QuantidadeItem = 10;

        //Item sugador = new Item();
        //sugador.IdFornecedor = 1;
        //sugador.Descricao = "Sugador";
        //sugador.Marca = "Brastemp";
        //sugador.UnidadeMedida = "UN";
        //sugador.QuantidadeEstoque = 2;
        //sugador.ValorUnitario = 10;

        //var optionsBuilder = new DbContextOptionsBuilder<OdontoCloudDBContext>();
        //var context = new OdontoCloudDBContext(optionsBuilder.Options);

        //var repository = new AtendimentoRepository(context);
        //repository.Save(atendimento);

        app.Run();
    }
}