using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class UpdateComandaDto{

        [Required]
        [Column("statuscomanda")]
        public bool StatusComanda {get; set;}

        [Required]
        [Column("dtcomanda")]
        public DateTime DtComanda { get; set; } = DateTime.Now;

        public int garcom_id { get; set; }
    }
}