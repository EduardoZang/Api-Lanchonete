using AutoMapper;
using LanchoneteApi.Data;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteApi.Controllers{

    [ApiController]
    [Route("[controller]")]

    public class GarcomController : ControllerBase{
        private LanchoneteContext _context;
        private IMapper _mapper;

    public GarcomController(LanchoneteContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona um graçom ao banco de dados
    ///</summary>
    ///<param name="addGarcomDto">Objeto com os campos necessários para o cadastro de um garçom</param>
    ///<returns>IActionResult</returns>
    ///<response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddGarcom([FromBody] CreateGarcomDto addGarcomDto){

                Garcom addGarcom = _mapper.Map<Garcom>(addGarcomDto);

                _context.Garcons.Add(addGarcom);
                _context.SaveChanges();

                return CreatedAtAction(nameof(VisualizaGarcom),new {id = addGarcom._id},addGarcom);
            } 

    ///<summary>
    ///Exibe todos os garçons do banco de dados
    ///</summary>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso a exibição seja feita com sucesso</response>
    [HttpGet]
        public IEnumerable<ReadGarcomDto> VisualizaGarcom([FromQuery] int skip = 0,[FromQuery] int take = 50){
            return  _mapper.Map<List<ReadGarcomDto>>(_context.Garcons.Skip(skip).Take(take));
        } 

    ///<summary>
    ///Exibe um garçom esecífico através do ID
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exibição de um garçom</param>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
            public IActionResult VisualizaGarcomId(int id){
               var exibeGarcom =  _context.Garcons.FirstOrDefault(exibeGarcom => exibeGarcom._id == id);
               if(exibeGarcom == null) return NotFound();
               var exibeGarcomDto = _mapper.Map<ReadGarcomDto>(exibeGarcom);
                return Ok(exibeGarcomDto);
            } 

    ///<summary>
    ///Altera dados de um garçom específico
    ///</summary>
    ///<param name="upGarcomDto">Objeto com os campos necessários para a alteração de um garçom</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
            public IActionResult AtualizaGarcom(int id, [FromBody] UpdateGarcomDto upGarcomDto){
                var upGarcom = _context.Garcons.FirstOrDefault(upGarcom => upGarcom._id == id);

                if(upGarcom == null) return NotFound();
                _mapper.Map(upGarcomDto,upGarcom);
                _context.SaveChanges();
                return NoContent();
            }   

     ///<summary>
    ///Exclui um garçom específico
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exclusão de um garçom</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso a exclusão seja feita com sucesso</response>
     [HttpDelete("{id}")]
            public IActionResult DeletaGarcom(int id){
                var deletaGarcom = _context.Garcons.FirstOrDefault(deletaGarcom => deletaGarcom._id == id);

                if(deletaGarcom == null) return NotFound();
                _context.Remove(deletaGarcom);
                _context.SaveChanges();
                return NoContent();
            }    
    }     
}