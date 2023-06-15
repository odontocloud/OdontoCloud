using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Cliente;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public ClienteController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um cliente ao banco de dados
        /// </summary>
        /// <param name="clienteDTO">Objeto com os campos necessarios para criacao de um cliente</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostCliente([FromBody] ClienteWriteDTO clienteWriteDTO)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            Cliente cliente = _mapper.Map<Cliente>(clienteWriteDTO);

            repository.Save(cliente);

            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Retorna uma lista de clientes do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ClienteReadDTO> GetClientes([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            List<Cliente> clienteList = repository.FindAll();

            return _mapper.Map<List<ClienteReadDTO>>(clienteList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um cliente do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um cliente</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o cliente nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClienteById(int id)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            Cliente cliente = repository.FindById(id);

            if (cliente == null) return NotFound();

            var clienteReadDTO = _mapper.Map<ClienteReadDTO>(cliente);

            return Ok(clienteReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um cliente no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um cliente</param>
        /// <param name="clienteDTO">Objeto com os campos necessarios para atualizacao de um cliente</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o cliente a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutCliente(int id, [FromBody] ClienteWriteDTO clienteWriteDTO)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            Cliente cliente = repository.FindById(id);

            if (cliente == null) return NotFound();

            _mapper.Map(clienteWriteDTO, cliente);

            repository.Update(cliente);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um cliente no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um cliente</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um cliente (em formato JsonPatchDocument<ClienteWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o cliente a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchCliente(int id, JsonPatchDocument<ClienteWriteDTO> patch)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            Cliente cliente = repository.FindById(id);

            if (cliente == null) return NotFound();

            var clienteToUpdate = _mapper.Map<ClienteWriteDTO>(cliente);

            patch.ApplyTo(clienteToUpdate, ModelState);

            if (!TryValidateModel(clienteToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(clienteToUpdate, cliente);

            repository.Update(cliente);

            return NoContent();
        }

        /// <summary>
        /// Apaga um cliente no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um cliente</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o cliente a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCliente(int id)
        {
            ClienteRepository repository = new ClienteRepository(_context);

            Cliente cliente = repository.FindById(id);

            if (cliente == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}