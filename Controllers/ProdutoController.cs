using AutoMapper;
using LanchoneteApi.Data;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteApi.Controllers{

    [ApiController]
    [Route("[controller]")]

    public class ProdutoController : ControllerBase{
        private LanchoneteContext _context;
        private IMapper _mapper;

    public ProdutoController(LanchoneteContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona um produto ao banco de dados
    ///</summary>
    ///<param name="addProdutoDto">Objeto com os campos necessários para o cadastro de um produto</param>
    ///<returns>IActionResult</returns>
    ///<response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddProduto([FromBody] CreateProdutoDto addProdutoDto){

                Produto addProduto = _mapper.Map<Produto>(addProdutoDto);

                _context.Produtos.Add(addProduto);
                _context.SaveChanges();

                return CreatedAtAction(nameof(VisualizaProduto),new {id = addProduto._id},addProduto);
            } 

    ///<summary>
    ///Exibe todos os produtos do banco de dados
    ///</summary>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso a exibição seja feita com sucesso</response>
    [HttpGet]
        public IEnumerable<ReadProdutoDto> VisualizaProduto([FromQuery] int skip = 0,[FromQuery] int take = 50){
            return  _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.Skip(skip).Take(take));
        } 

    ///<summary>
    ///Exibe um produto específico através do ID
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exibição de um produto</param>
    ///<returns>IActionResult</returns>
    ///<response code="200">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
            public IActionResult VisualizaProdutoId(int id){
               var exibeProduto =  _context.Produtos.FirstOrDefault(exibeProduto => exibeProduto._id == id);
               if(exibeProduto == null) return NotFound();
               var exibeProdutoDto = _mapper.Map<ReadProdutoDto>(exibeProduto);
                return Ok(exibeProdutoDto);
            } 

    ///<summary>
    ///Altera dados de um produto específico
    ///</summary>
    ///<param name="upProdutoDto">Objeto com os campos necessários para a alteração de um produto</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
            public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDto upProdutoDto){
                var upProduto = _context.Produtos.FirstOrDefault(upProduto => upProduto._id == id);

                if(upProduto == null) return NotFound();
                _mapper.Map(upProdutoDto,upProduto);
                _context.SaveChanges();
                return NoContent();
            }   

     ///<summary>
    ///Exclui um produto específico
    ///</summary>
    ///<param name="id">Objeto com os campos necessários para a exclusão de um produto</param>
    ///<returns>IActionResult</returns>
    ///<response code="204">Caso a exclusão seja feita com sucesso</response>
     [HttpDelete("{id}")]
            public IActionResult DeletaProduto(int id){
                var deletaProduto = _context.Produtos.FirstOrDefault(deletaProduto => deletaProduto._id == id);

                if(deletaProduto == null) return NotFound();
                _context.Remove(deletaProduto);
                _context.SaveChanges();
                return NoContent();
            }    
    }     
}