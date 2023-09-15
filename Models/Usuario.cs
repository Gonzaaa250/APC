using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models;

public class Usuario
{
     [Key]
     public int UsuarioId { get; set; }
     public string Localidad { get; set; }
     public string Nombre { get; set; }
     public string Telefono { get; set; }
     public string DNI { get; set; }
     public string Categoria { get; set; }
     public bool Eliminado { get; set; }
     public Genero Genero { get; set; }
     public int ClubId {get; set;}
     public virtual Club? Club { get; set; }
}

public class ListadoUsuarios
{
     public int UsuarioId { get; set; }
     public string Localidad { get; set; }
     public string Nombre { get; set; }
     public string Telefono { get; set; }
     public string DNI { get; set; }
     public Genero Genero { get; set; }
     public string Categoria { get; set; }
     public bool Eliminado { get; set; }
     public string ClubNombre { get; set; }
}

public enum Genero
{
     Masculino = 1,
     Femenino = 2,
}
