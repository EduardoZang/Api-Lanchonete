using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Models{
    
    [Table("produto")]
    public class Produto{
        [Key]
        [Required]
        [Column("idproduto")]
        public int _id {get; set;}

        [Required]
        [Column("nmproduto")]
        public string NmProduto {get; set;}

        [Required]
        [Column("descricaoproduto")]
        public string Descricaoproduto { get; set; }

        [Required]
        [Column("vlproduto")]
        public double VlProduto { get; set; }

        [Required]
        [Column("tipo_id")]
        public int tipo_id { get; set; }
        public Tipo tipo { get; set; }
        
    }
}