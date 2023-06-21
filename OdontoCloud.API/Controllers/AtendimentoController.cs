using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Atendimento;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public AtendimentoController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um atendimento ao banco de dados
        /// </summary>
        /// <param name="atendimentoDTO">Objeto com os campos necessarios para criacao de um atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostAtendimento([FromBody] AtendimentoWriteDTO atendimentoWriteDTO)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            Atendimento atendimento = _mapper.Map<Atendimento>(atendimentoWriteDTO);

            repository.Save(atendimento);

            return CreatedAtAction(nameof(GetAtendimentoById), new { id = atendimento.Id }, atendimento);
        }

        /// <summary>
        /// Retorna uma lista de atendimentos do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<AtendimentoReadDTO> GetAtendimentos([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            List<Atendimento> atendimentoList = repository.FindAll();

            return _mapper.Map<List<AtendimentoReadDTO>>(atendimentoList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um atendimento do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o atendimento nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAtendimentoById(int id)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            Atendimento atendimento = repository.FindById(id);

            if (atendimento == null) return NotFound();

            var atendimentoReadDTO = _mapper.Map<AtendimentoReadDTO>(atendimento);

            return Ok(atendimentoReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um atendimento</param>
        /// <param name="atendimentoDTO">Objeto com os campos necessarios para atualizacao de um atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o atendimento a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutAtendimento(int id, [FromBody] AtendimentoWriteDTO atendimentoWriteDTO)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            Atendimento atendimento = repository.FindById(id);

            if (atendimento == null) return NotFound();

            _mapper.Map(atendimentoWriteDTO, atendimento);

            repository.Update(atendimento);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um atendimento</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um atendimento (em formato JsonPatchDocument<AtendimentoWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o atendimento a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchAtendimento(int id, JsonPatchDocument<AtendimentoWriteDTO> patch)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            Atendimento atendimento = repository.FindById(id);

            if (atendimento == null) return NotFound();

            var atendimentoToUpdate = _mapper.Map<AtendimentoWriteDTO>(atendimento);

            patch.ApplyTo(atendimentoToUpdate, ModelState);

            if (!TryValidateModel(atendimentoToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(atendimentoToUpdate, atendimento);

            repository.Update(atendimento);

            return NoContent();
        }

        /// <summary>
        /// Apaga um atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o atendimento a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteAtendimento(int id)
        {
            AtendimentoRepository repository = new AtendimentoRepository(_context);

            Atendimento atendimento = repository.FindById(id);

            if (atendimento == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}