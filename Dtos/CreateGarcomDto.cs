using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{
    public class CreateGarcomDto{
    
        [Required]
        [Column("nmgarcom")]
        public string NomeGarcom {get; set;}

        [Required]
        [Column("numeromesa")]
        public int NumeroMesa {get; set;}
        }
    }