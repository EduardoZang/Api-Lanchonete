using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Models{
    
    [Table("tipo")]
    public class Tipo{
        [Key]
        [Required]
        [Column("idtipo")]
        public int _id {get; set;}

        [Required]
        [Column("nmtipo")]
        public string NmTipo {get; set;}
        
    }
}