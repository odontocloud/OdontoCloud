using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Anamnese;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnamneseController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public AnamneseController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma anamnese ao banco de dados
        /// </summary>
        /// <param name="anamneseDTO">Objeto com os campos necessarios para criacao de uma anamnese</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostAnamnese([FromBody] AnamneseWriteDTO anamneseWriteDTO)
        {
            AnamneseRepository repository = new(_context);

            Anamnese anamnese = _mapper.Map<Anamnese>(anamneseWriteDTO);

            repository.Save(anamnese);

            return CreatedAtAction(nameof(GetAnamneseById), new { id = anamnese.Id }, anamnese);
        }

        /// <summary>
        /// Retorna uma lista de anamneses do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<AnamneseReadDTO> GetAnamneses([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            AnamneseRepository repository = new(_context);

            List<Anamnese> anamneseList = repository.FindAll();

            return _mapper.Map<List<AnamneseReadDTO>>(anamneseList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna uma anamnese do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de uma anamnese</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso a anamnese nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAnamneseById(int id)
        {
            AnamneseRepository repository = new(_context);

            Anamnese anamnese = repository.FindById(id);

            if (anamnese == null) return NotFound();

            var anamneseReadDTO = _mapper.Map<AnamneseReadDTO>(anamnese);

            return Ok(anamneseReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de uma anamnese no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de uma anamnese</param>
        /// <param name="anamneseDTO">Objeto com os campos necessarios para atualizacao de uma anamnese</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso a anamnese a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutAnamnese(int id, [FromBody] AnamneseWriteDTO anamneseWriteDTO)
        {
            AnamneseRepository repository = new(_context);

            Anamnese anamnese = repository.FindById(id);

            if (anamnese == null) return NotFound();

            _mapper.Map(anamneseWriteDTO, anamnese);

            repository.Update(anamnese);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de uma anamnese no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de uma anamnese</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de uma anamnese (em formato JsonPatchDocument<AnamneseWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso a anamnese a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchAnamnese(int id, JsonPatchDocument<AnamneseWriteDTO> patch)
        {
            AnamneseRepository repository = new(_context);

            Anamnese anamnese = repository.FindById(id);

            if (anamnese == null) return NotFound();

            var anamneseToUpdate = _mapper.Map<AnamneseWriteDTO>(anamnese);

            patch.ApplyTo(anamneseToUpdate, ModelState);

            if (!TryValidateModel(anamneseToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(anamneseToUpdate, anamnese);

            repository.Update(anamnese);

            return NoContent();
        }

        /// <summary>
        /// Apaga uma anamnese no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar uma anamnese</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso a anamnese a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteAnamnese(int id)
        {
            AnamneseRepository repository = new(_context);

            Anamnese anamnese = repository.FindById(id);

            if (anamnese == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}