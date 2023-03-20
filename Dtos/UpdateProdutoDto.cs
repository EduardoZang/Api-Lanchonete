using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class UpdateProdutoDto{
        
        [Required]
        [Column("nmproduto")]
        public string NmProduto {get; set;}

        [Required]
        [Column("descricaoproduto")]
        public string Descricaoproduto { get; set; }

        [Required]
        [Column("vlproduto")]
        public double VlProduto { get; set; }
        
        public int tipo_id { get; set; }
    }
}