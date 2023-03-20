using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class UpdateItemComandaDto{
        
        [Required]
        [Column("vlvenda")]
        public double VlVenda {get; set;}

        public int comanda_id { get; set; }
        
        public int produto_id { get; set; }
    }
}