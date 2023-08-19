using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models;
public class Usuario
{
     [Key]
     public int UsuarioId { get; set; }
     public string Localidad { get; set; }
     public string Nombre { get; set; }
     public DateTime Edad { get; set; }
     [NotMapped]
     public int UsuarioAge
     {
          get
          {
               return DateTime.Now.Year - Edad.Year;
          }
     }
     public string Telefono { get; set; }
     public string DNI { get; set; }
     public bool Eliminado {get; set;}
     public virtual ICollection<Categoria>? Categoria{get;set;}
     public virtual Club? Club{get; set;}
}