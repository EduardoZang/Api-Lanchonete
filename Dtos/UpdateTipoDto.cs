using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class UpdateTipoDto{
        
       [Required]
        [Column("nmtipo")]
        public string NmTipo {get; set;}
    }
}