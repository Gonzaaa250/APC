using System.ComponentModel.DataAnnotations;
namespace TesisPadel.Models;
public class Categoria{
    [Key]
    public int CategoriaId { get; set; }
    
    public virtual ICollection<Ranking>? Rankings {get; set;}
}







