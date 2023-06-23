using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.DetalheAtendimento;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalheAtendimentoController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public DetalheAtendimentoController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um detalhe de atendimento ao banco de dados
        /// </summary>
        /// <param name="detalheatendimentoDTO">Objeto com os campos necessarios para criacao de um detalhe de atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostDetalheAtendimento([FromBody] DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            DetalheAtendimento detalheAtendimento = _mapper.Map<DetalheAtendimento>(detalheAtendimentoWriteDTO);

            repository.Save(detalheAtendimento);

            return CreatedAtAction(nameof(GetDetalheAtendimentoById), new { id = detalheAtendimento.Id }, detalheAtendimento);
        }

        /// <summary>
        /// Retorna uma lista de detalhes de atendimento do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<DetalheAtendimentoReadDTO> GetDetalhesAtendimento([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            List<DetalheAtendimento> detalheAtendimentoList = repository.FindAll();

            return _mapper.Map<List<DetalheAtendimentoReadDTO>>(detalheAtendimentoList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um detalhe de atendimento do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um detalhe de atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o detalhe de atendimento nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDetalheAtendimentoById(int id)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            DetalheAtendimento detalheAtendimento = repository.FindById(id);

            if (detalheAtendimento == null) return NotFound();

            var detalheAtendimentoReadDTO = _mapper.Map<DetalheAtendimentoReadDTO>(detalheAtendimento);

            return Ok(detalheAtendimentoReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um detalhe de atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um detalhe de atendimento</param>
        /// <param name="detalheatendimentoDTO">Objeto com os campos necessarios para atualizacao de um detalhe de atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o detalhe de atendimento a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutDetalheAtendimento(int id, [FromBody] DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            DetalheAtendimento detalheAtendimento = repository.FindById(id);

            if (detalheAtendimento == null) return NotFound();

            _mapper.Map(detalheAtendimentoWriteDTO, detalheAtendimento);

            repository.Update(detalheAtendimento);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um detalhe de atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um detalhe de atendimento</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um detalhe de atendimento (em formato JsonPatchDocument<DetalheAtendimentoWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o detalhe de atendimento a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchDetalheAtendimento(int id, JsonPatchDocument<DetalheAtendimentoWriteDTO> patch)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            DetalheAtendimento detalheAtendimento = repository.FindById(id);

            if (detalheAtendimento == null) return NotFound();

            var detalheAtendimentoToUpdate = _mapper.Map<DetalheAtendimentoWriteDTO>(detalheAtendimento);

            patch.ApplyTo(detalheAtendimentoToUpdate, ModelState);

            if (!TryValidateModel(detalheAtendimentoToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(detalheAtendimentoToUpdate, detalheAtendimento);

            repository.Update(detalheAtendimento);

            return NoContent();
        }

        /// <summary>
        /// Apaga um detalhe de atendimento no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um detalhe de atendimento</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o detalhe de atendimento a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteDetalheAtendimento(int id)
        {
            DetalheAtendimentoRepository repository = new DetalheAtendimentoRepository(_context);

            DetalheAtendimento detalheAtendimento = repository.FindById(id);

            if (detalheAtendimento == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}