using AutoMapper;
using LanchoneteApi.Data;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteApi.Controllers{

    [ApiController]
    [Route("[controller]")]

    public class ComandaController : ControllerBase{
        private LanchoneteContext _context;
        private IMapper _mapper;

    public ComandaController(LanchoneteContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona uma comanda ao banco de dados
    ///</summary>
    ///<param name="addComandaDto">Objeto com os campos necessários para o cadastro de uma comada</param>
    ///<returns>IActionResult</returns>
    ///<response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddComanda([FromBody] CreateComandaDto addComandaDto){

                Comanda addComanda = _mapper.Map<Comanda>(addComandaDto);

                _context.Comandas.Add(addComanda);
                _context.SaveChanges();

                return CreatedAtAction(nameof(VisualizaComanda),new {id = addComanda._id},addComanda);
            } 

    ///<summary>
    ///Exibe todas as comandas do banco de dados
    ///</summary>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso a exibição seja feita com sucesso</response>
    [HttpGet]
        public IEnumerable<ReadComandaDto> VisualizaComanda([FromQuery] int skip = 0,[FromQuery] int take = 50){    
            return  _mapper.Map<List<ReadComandaDto>>(_context.Comandas
                                                        .Include(comanda => comanda.itens)
                                                        .Skip(skip)
                                                        .Take(take));
        } 

    ///<summary>
    ///Exibe uma comanda específica através do ID
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exibição de uma comada</param>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
            public IActionResult VisualizaComandaId(int id){
               var exibeComanda =  _context.Comandas
                                            .Include(comanda => comanda.itens)
                                            .FirstOrDefault(exibeComanda => exibeComanda._id == id);
               if(exibeComanda == null) return NotFound();
               var exibeComandaDto = _mapper.Map<ReadComandaDto>(exibeComanda);
                return Ok(exibeComandaDto);
            } 

    ///<summary>
    ///Altera dados de uma comanda específica
    ///</summary>
    ///<param name="addComandaDto">Objeto com os campos necessários para a alteração de uma comada</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
            public IActionResult AtualizaComanda(int id, [FromBody] UpdateComandaDto upComandaDto){
                var upComanda = _context.Comandas.FirstOrDefault(upComanda => upComanda._id == id);

                if(upComanda == null) return NotFound();
                _mapper.Map(upComandaDto,upComanda);
                _context.SaveChanges();
                return NoContent();
            }   

     ///<summary>
    ///Exclui uma comanda específica
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exclusão de uma comada</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso a exclusão seja feita com sucesso</response>
     [HttpDelete("{id}")]
            public IActionResult DeletaComanda(int id){
                var deletaComanda = _context.Comandas.FirstOrDefault(deletaComanda => deletaComanda._id == id);

                if(deletaComanda == null) return NotFound();
                _context.Remove(deletaComanda);
                _context.SaveChanges();
                return NoContent();
            }    
    }     
}