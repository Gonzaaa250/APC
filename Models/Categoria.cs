using System.ComponentModel.DataAnnotations;
namespace TesisPadel.Models;
public class Categoria{
    [Key]
    public int CategoriaId { get; set; }
    
    public virtual ICollection<Ranking>? Rankings {get; set;}
}
public class Enum{
     public enum Opcion
    {
        Masculino,
        Femenino
    }

    public Opcion Categoria { get; set; }
    Enum miEnum = new Enum();

// Console.WriteLine("Elige una opción: ");
// Console.WriteLine("1. Masculino");
// Console.WriteLine("2. Femenino");

// int opcion = Convert.ToInt32(Console.ReadLine());

// switch (opcion)
// {
//     case 1:
//         miEnum.Categoria = Enum.Opcion.Masculino;
//         break;
//     case 2:
//         miEnum.Categoria = Enum.Opcion.Femenino;
//         break;
//     default:
//         Console.WriteLine("Opción inválida");
//         break;
// }

// Console.WriteLine("La opción elegida es: " + miEnum.Categoria);

}






