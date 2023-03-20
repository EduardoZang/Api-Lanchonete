using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Models{
    
    [Table("itemComanda")]
    public class ItemComanda{
        [Key]
        [Required]
        [Column("iditemcomanda")]
        public int _id {get; set;}

        [Required]
        [Column("vlvenda")]
        public double VlVenda {get; set;}

        [Required]
        [Column("comanda_id")]
        public int comanda_id { get; set; }
        public Comanda comanda { get; set; }

        [Required]
        [Column("produto_id")]
        public int produto_id { get; set; }
        public Produto produto { get; set; }
    }
}