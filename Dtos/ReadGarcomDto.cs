using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteApi.Dtos{

    public class ReadGarcomDto{
       public string NomeGarcom {get; set;}
       public int NumeroMesa {get; set;}
    }
}