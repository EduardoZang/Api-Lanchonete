using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class ReadProdutoDto{
       public string NmProduto {get; set;}
       public string Descricaoproduto { get; set; }
       public double VlProduto { get; set; }
       public int tipo_id { get; set; }
    }
}