using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Models{
    
    [Table("garcom")]
    public class Garcom{
        [Key]
        [Required]
        [Column("idgarcom")]
        public int _id {get; set;}

        [Required]
        [Column("nmgarcom")]
        public string NomeGarcom {get; set;}

        [Required]
        [Column("numeromesa")]
        public int NumeroMesa {get; set;}
    }
}