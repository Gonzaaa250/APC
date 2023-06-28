using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models;
public class Usuario {
    [Key]
    public int UsuarioId {get; set;}
    public int LocalidadId { get; set;}
    public string? Nombre {get; set;} 
    public string? Apellido {get; set;}
     public DateTime EdadUsuario {get; set;}
    [NotMapped]
         public int UsuarioAge 
        {
           get
           {
                return DateTime.Now.Year - EdadUsuario.Year;
            } 
       }
    public string? Telefono {get; set;}
    public string? DNI {get;set;}
    public string? Direccion {get; set;}
    public bool Eliminado {get; set;}
    }