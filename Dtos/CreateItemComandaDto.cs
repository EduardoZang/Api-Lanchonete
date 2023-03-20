using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{
    public class CreateItemComandaDto{
    
        [Required]
        [Column("vlvenda")]
        public double VlVenda {get; set;}

       
        [ForeignKey("comanda_id")]
         [Required]
        public int comanda_id { get; set; }
        
        
        [ForeignKey("produto_id")]
        [Required]
        public int produto_id { get; set; }
        }
    }