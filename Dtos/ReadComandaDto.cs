using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LanchoneteApi.Models;
namespace LanchoneteApi.Dtos{

    public class ReadComandaDto{
        public bool StatusComanda {get; set;}
        public DateTime DtComanda { get; set; } = DateTime.Now;
        public int garcom_id { get; set; }

        public double valorTotal {get; set;}
    
    }
}