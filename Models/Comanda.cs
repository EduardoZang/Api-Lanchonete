using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Models{
    
    [Table("comanda")]
    public class Comanda{
        [Key]
        [Required]
        [Column("idcomanda")]
        public int _id {get; set;}

        [Required]
        [Column("statuscomanda")]
        public bool StatusComanda {get; set;}

        [Required]
        [Column("garcom_id")]
        public int garcom_id { get; set; }
        public Garcom garcom { get; set; }
    }
}