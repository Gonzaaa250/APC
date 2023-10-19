using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TesisPadel.Models;
public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }
    public string Tipo { get; set; } 
    public bool Eliminado { get; set; }
    public virtual ICollection <Usuario> Usuario {get; set;}
}
