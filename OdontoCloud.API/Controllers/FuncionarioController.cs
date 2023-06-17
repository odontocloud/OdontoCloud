using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Funcionario;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public FuncionarioController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um funcionario ao banco de dados
        /// </summary>
        /// <param name="funcionarioDTO">Objeto com os campos necessarios para criacao de um funcionario</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostFuncionario([FromBody] FuncionarioWriteDTO funcionarioWriteDTO)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioWriteDTO);

            repository.Save(funcionario);

            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
        }

        /// <summary>
        /// Retorna uma lista de funcionarios do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<FuncionarioReadDTO> GetFuncionarios([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            List<Funcionario> funcionarioList = repository.FindAll();

            return _mapper.Map<List<FuncionarioReadDTO>>(funcionarioList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um funcionario do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um funcionario</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o funcionario nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFuncionarioById(int id)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            Funcionario funcionario = repository.FindById(id);

            if (funcionario == null) return NotFound();

            var funcionarioReadDTO = _mapper.Map<FuncionarioReadDTO>(funcionario);

            return Ok(funcionarioReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um funcionario no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um funcionario</param>
        /// <param name="funcionarioDTO">Objeto com os campos necessarios para atualizacao de um funcionario</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o funcionario a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutFuncionario(int id, [FromBody] FuncionarioWriteDTO funcionarioWriteDTO)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            Funcionario funcionario = repository.FindById(id);

            if (funcionario == null) return NotFound();

            _mapper.Map(funcionarioWriteDTO, funcionario);

            repository.Update(funcionario);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um funcionario no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um funcionario</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um funcionario (em formato JsonPatchDocument<FuncionarioWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o funcionario a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchFuncionario(int id, JsonPatchDocument<FuncionarioWriteDTO> patch)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            Funcionario funcionario = repository.FindById(id);

            if (funcionario == null) return NotFound();

            var funcionarioToUpdate = _mapper.Map<FuncionarioWriteDTO>(funcionario);

            patch.ApplyTo(funcionarioToUpdate, ModelState);

            if (!TryValidateModel(funcionarioToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(funcionarioToUpdate, funcionario);

            repository.Update(funcionario);

            return NoContent();
        }

        /// <summary>
        /// Apaga um funcionario no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um funcionario</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o funcionario a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteFuncionario(int id)
        {
            FuncionarioRepository repository = new FuncionarioRepository(_context);

            Funcionario funcionario = repository.FindById(id);

            if (funcionario == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}