using AutoMapper;
using LanchoneteApi.Data;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteApi.Controllers{

    [ApiController]
    [Route("[controller]")]

    public class ItemComandaController : ControllerBase{
        private LanchoneteContext _context;
        private IMapper _mapper;

    public ItemComandaController(LanchoneteContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona um item para o cardápio no banco de dados
    ///</summary>
    ///<param name="addItemDto">Objeto com os campos necessários para o cadastro de um novo item</param>
    ///<returns>IActionResult</returns>
    ///<response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddItem([FromBody] CreateItemComandaDto addItemDto){

                ItemComanda addItem = _mapper.Map<ItemComanda>(addItemDto);

                _context.ItensComandas.Add(addItem);
                _context.SaveChanges();

                return CreatedAtAction(nameof(VisualizaItem),new {id = addItem._id},addItem);
            } 

    ///<summary>
    ///Exibe todos os itens do cardápio salvos no banco de dados
    ///</summary>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso a exibição seja feita com sucesso</response>
    [HttpGet]
        public IEnumerable<ReadItemComandaDto> VisualizaItem([FromQuery] int skip = 0,[FromQuery] int take = 50){
            return  _mapper.Map<List<ReadItemComandaDto>>(_context.ItensComandas.Skip(skip).Take(take));
        } 

    ///<summary>
    ///Exibe um item específico através do ID
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exibição de um item</param>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
            public IActionResult VisualizaItemId(int id){
               var exibeItem =  _context.ItensComandas.FirstOrDefault(exibeItem => exibeItem._id == id);
               if(exibeItem == null) return NotFound();
               var addItemDto = _mapper.Map<ReadItemComandaDto>(exibeItem);
                return Ok(addItemDto);
            } 

    ///<summary>
    ///Altera dados de um item específico
    ///</summary>
    ///<param name="upItemDto">Objeto com os campos necessários para a alteração de um item</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
            public IActionResult AtualizaItem(int id, [FromBody] UpdateItemComandaDto upItemDto){
                var upItem = _context.ItensComandas.FirstOrDefault(upItem => upItem._id == id);

                if(upItem == null) return NotFound();
                _mapper.Map(upItemDto,upItem);
                _context.SaveChanges();
                return NoContent();
            }   

     ///<summary>
    ///Exclui um item do cardápio
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exclusão de um item</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso a exclusão seja feita com sucesso</response>
     [HttpDelete("{id}")]
            public IActionResult DeletaItem(int id){
                var deletaItem = _context.ItensComandas.FirstOrDefault(deletaItem => deletaItem._id == id);

                if(deletaItem == null) return NotFound();
                _context.Remove(deletaItem);
                _context.SaveChanges();
                return NoContent();
            }    
    }     
}