using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.Infrastructure.DTOs.Item;
using OdontoCloud.Infrastructure.Repositories;

namespace OdontoCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private OdontoCloudDBContext _context;
        private IMapper _mapper;

        public ItemController(OdontoCloudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um item ao banco de dados
        /// </summary>
        /// <param name="itemDTO">Objeto com os campos necessarios para criacao de um item</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso insercao seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostItem([FromBody] ItemWriteDTO itemWriteDTO)
        {
            ItemRepository repository = new ItemRepository(_context);

            Item item = _mapper.Map<Item>(itemWriteDTO);

            repository.Save(item);

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        /// <summary>
        /// Retorna uma lista de itens do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ItemReadDTO> GetItens([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            ItemRepository repository = new ItemRepository(_context);

            List<Item> itemList = repository.FindAll();

            return _mapper.Map<List<ItemReadDTO>>(itemList.Skip(skip).Take(take).ToArray());
        }

        /// <summary>
        /// Retorna um item do banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um item</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a consulta seja feita com sucesso</response>
        /// <response code="404">Caso o item nao seja identificado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetItemById(int id)
        {
            ItemRepository repository = new ItemRepository(_context);

            Item item = repository.FindById(id);

            if (item == null) return NotFound();

            var itemReadDTO = _mapper.Map<ItemReadDTO>(item);

            return Ok(itemReadDTO);
        }

        /// <summary>
        /// Atualiza todos os campos de um item no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um item</param>
        /// <param name="itemDTO">Objeto com os campos necessarios para atualizacao de um item</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o item a ser atualizado nao seja identificado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutItem(int id, [FromBody] ItemWriteDTO itemWriteDTO)
        {
            ItemRepository repository = new ItemRepository(_context);

            Item item = repository.FindById(id);

            if (item == null) return NotFound();

            _mapper.Map(itemWriteDTO, item);

            repository.Update(item);

            return NoContent();
        }

        /// <summary>
        /// Atualiza campos especificos de um item no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para consulta de um item</param>
        /// <param name="patch">Lista dos campos necessarios para atualizacao de um item (em formato JsonPatchDocument<ItemWriteDTO>)</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualizacao seja feita com sucesso</response>
        /// <response code="404">Caso o item a ser atualizado nao seja identificado</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchItem(int id, JsonPatchDocument<ItemWriteDTO> patch)
        {
            ItemRepository repository = new ItemRepository(_context);

            Item item = repository.FindById(id);

            if (item == null) return NotFound();

            var itemToUpdate = _mapper.Map<ItemWriteDTO>(item);

            patch.ApplyTo(itemToUpdate, ModelState);

            if (!TryValidateModel(itemToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToUpdate, item);

            repository.Update(item);

            return NoContent();
        }

        /// <summary>
        /// Apaga um item no banco de dados
        /// </summary>
        /// <param name="id">Campo identificador necessario para apagar um item</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a delecao seja feita com sucesso</response>
        /// <response code="404">Caso o item a ser apagado nao seja identificado</response>	
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteItem(int id)
        {
            ItemRepository repository = new ItemRepository(_context);

            Item item = repository.FindById(id);

            if (item == null) return NotFound();

            repository.DeleteById(id);

            return NoContent();
        }
    }
}