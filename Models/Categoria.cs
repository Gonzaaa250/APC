using System.ComponentModel.DataAnnotations;
namespace TesisPadel.Models;
public class Categoria{
    [Key]
    public int CategoriaId { get; set; }

    public Genero genero {get; set;}
}
public enum Genero
{
    Masculino = 1,
    Femenino
}






