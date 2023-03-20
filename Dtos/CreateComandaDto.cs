using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{
    public class CreateComandaDto{
    
        [Required]
        [Column("statuscomanda")]
        public bool StatusComanda {get; set;}

        [Required]
        [Column("dtcomanda")]
        public DateTime DtComanda { get; set; } = DateTime.Now;

       [ForeignKey("garcom_id")]
       [Required]
        public int garcom_id { get; set; }
        }
    }