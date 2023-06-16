using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Endereco;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public EnderecoController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um endereco ao banco de dados
        /// </summary>
        /// <param name="enderecoDTO">Objeto com os campos necessarios para criacao de um endereco</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostEndereco([FromBody] EnderecoWriteDTO enderecoWriteDTO)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            Endereco endereco = _mapper.Map<Endereco>(enderecoWriteDTO);

            repository.Save(endereco);

            return CreatedAtAction(nameof(GetEnderecoById), new { id = endereco.Id }, endereco);
        }

        /// <summary>
        /// Retorna uma lista de enderecos do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<EnderecoReadDTO> GetEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            List<Endereco> enderecoList = repository.FindAll();

            return _mapper.Map<List<EnderecoReadDTO>>(enderecoList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um endereco do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um endereco</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o endereco nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEnderecoById(int id)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            Endereco endereco = repository.FindById(id);

            if (endereco == null) return NotFound();

            var enderecoReadDTO = _mapper.Map<EnderecoReadDTO>(endereco);

            return Ok(enderecoReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um endereco no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um endereco</param>
        /// <param name="enderecoDTO">Objeto com os campos necessarios para atualizacao de um endereco</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o endereco a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutEndereco(int id, [FromBody] EnderecoWriteDTO enderecoWriteDTO)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            Endereco endereco = repository.FindById(id);

            if (endereco == null) return NotFound();

            _mapper.Map(enderecoWriteDTO, endereco);

            repository.Update(endereco);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um endereco no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um endereco</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um endereco (em formato JsonPatchDocument<ClienteWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o endereco a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchEndereco(int id, JsonPatchDocument<EnderecoWriteDTO> patch)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            Endereco endereco = repository.FindById(id);

            if (endereco == null) return NotFound();

            var enderecoToUpdate = _mapper.Map<EnderecoWriteDTO>(endereco);

            patch.ApplyTo(enderecoToUpdate, ModelState);

            if (!TryValidateModel(enderecoToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(enderecoToUpdate, endereco);

            repository.Update(endereco);

            return NoContent();
        }

        /// <summary>
        /// Apaga um endereco no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um endereco</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o endereco a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteEndereco(int id)
        {
            EnderecoRepository repository = new EnderecoRepository(_context);

            Endereco endereco = repository.FindById(id);

            if (endereco == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}