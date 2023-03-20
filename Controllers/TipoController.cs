using AutoMapper;
using LanchoneteApi.Data;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteApi.Controllers{

    [ApiController]
    [Route("[controller]")]

    public class TipoController : ControllerBase{
        private LanchoneteContext _context;
        private IMapper _mapper;

    public TipoController(LanchoneteContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona um tipo ao banco de dados
    ///</summary>
    ///<param name="addTipoDto">Objeto com os campos necessários para o cadastro de um tipo</param>
    ///<returns>IActionResult</returns>
    ///<response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddTipo([FromBody] CreateTipoDto tipoDto){

                Tipo tipo = _mapper.Map<Tipo>(tipoDto);

                _context.Tipos.Add(tipo);
                _context.SaveChanges();

                return CreatedAtAction(nameof(VisualizaTipo),new {id = tipo._id},tipo);
            } 

    ///<summary>
    ///Exibe todos os tipos salvos no banco de dados
    ///</summary>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso a exibição seja feita com sucesso</response>
    [HttpGet]
        public IEnumerable<ReadTipoDto> VisualizaTipo([FromQuery] int skip = 0,[FromQuery] int take = 50){
            return  _mapper.Map<List<ReadTipoDto>>(_context.Tipos.Skip(skip).Take(take));
        } 

    ///<summary>
    ///Exibe um tipo específico através do ID
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exibição de um tipo</param>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
            public IActionResult VisualizaTipoId(int id){
               var exibeTipo =  _context.Tipos.FirstOrDefault(exibeTipo => exibeTipo._id == id);
               if(exibeTipo == null) return NotFound();
               var exibeTipoDto = _mapper.Map<ReadTipoDto>(exibeTipo);
                return Ok(exibeTipoDto);
            } 

    ///<summary>
    ///Altera dados de uma tipo específico
    ///</summary>
    ///<param name="upTipoDto">Objeto com os campos necessários para a alteração de uma comada</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
            public IActionResult AtualizaTipo(int id, [FromBody] UpdateTipoDto upTipoDto){
                var upTipo = _context.Tipos.FirstOrDefault(upTipo => upTipo._id == id);

                if(upTipo == null) return NotFound();
                _mapper.Map(upTipoDto,upTipo);
                _context.SaveChanges();
                return NoContent();
            }   

     ///<summary>
    ///Exclui um tipo específico
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exclusão de um tipo</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso a exclusão seja feita com sucesso</response>
     [HttpDelete("{id}")]
            public IActionResult DeletaTipo(int id){
                var deletaTipo = _context.Tipos.FirstOrDefault(deletaTipo => deletaTipo._id == id);

                if(deletaTipo == null) return NotFound();
                _context.Remove(deletaTipo);
                _context.SaveChanges();
                return NoContent();
            }    
    }     
}