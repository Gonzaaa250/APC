using System.ComponentModel.DataAnnotations;
namespace TesisPadel.Models;
public class Categoria{
    [Key]
    public int CategoriaId { get; set; } // revisar con el profe audizio

    //Chekear si esta bien la relacion
    //public virtual ICollection<Ranking>? Rankings {get; set;}
}