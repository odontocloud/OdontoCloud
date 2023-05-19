using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetClientes")]
        public IEnumerable<Cliente> Get()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdontoCloudDBContext>();
            var context = new OdontoCloudDBContext(optionsBuilder.Options);
            var repository = new ClienteRepository(context);

            List<Cliente> clienteList = repository.FindAll();

            return clienteList.ToArray();
        }
    }
}