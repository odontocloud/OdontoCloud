using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Fornecedor;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public FornecedorController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um fornecedor ao banco de dados
        /// </summary>
        /// <param name="fornecedorDTO">Objeto com os campos necessarios para criacao de um fornecedor</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostFornecedor([FromBody] FornecedorWriteDTO fornecedorWriteDTO)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorWriteDTO);

            repository.Save(fornecedor);

            return CreatedAtAction(nameof(GetFornecedorById), new { id = fornecedor.Id }, fornecedor);
        }

        /// <summary>
        /// Retorna uma lista de fornecedores do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<FornecedorReadDTO> GetFornecedores([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            List<Fornecedor> fornecedorList = repository.FindAll();

            return _mapper.Map<List<FornecedorReadDTO>>(fornecedorList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um fornecedor do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um fornecedor</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o fornecedor nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFornecedorById(int id)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            Fornecedor fornecedor = repository.FindById(id);

            if (fornecedor == null) return NotFound();

            var fornecedorReadDTO = _mapper.Map<FornecedorReadDTO>(fornecedor);

            return Ok(fornecedorReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um fornecedor no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um fornecedor</param>
        /// <param name="fornecedorDTO">Objeto com os campos necessarios para atualizacao de um fornecedor</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o fornecedor a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutFornecedor(int id, [FromBody] FornecedorWriteDTO fornecedorWriteDTO)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            Fornecedor fornecedor = repository.FindById(id);

            if (fornecedor == null) return NotFound();

            _mapper.Map(fornecedorWriteDTO, fornecedor);

            repository.Update(fornecedor);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um fornecedor no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um fornecedor</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um fornecedor (em formato JsonPatchDocument<FornecedorWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o fornecedor a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchFornecedor(int id, JsonPatchDocument<FornecedorWriteDTO> patch)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            Fornecedor fornecedor = repository.FindById(id);

            if (fornecedor == null) return NotFound();

            var fornecedorToUpdate = _mapper.Map<FornecedorWriteDTO>(fornecedor);

            patch.ApplyTo(fornecedorToUpdate, ModelState);

            if (!TryValidateModel(fornecedorToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(fornecedorToUpdate, fornecedor);

            repository.Update(fornecedor);

            return NoContent();
        }

        /// <summary>
        /// Apaga um fornecedor no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um fornecedor</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o fornecedor a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteFornecedor(int id)
        {
            FornecedorRepository repository = new FornecedorRepository(_context);

            Fornecedor fornecedor = repository.FindById(id);

            if (fornecedor == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}