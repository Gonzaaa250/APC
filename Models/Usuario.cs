using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Usuario {
    [Key]
    public int UsuarioId {get; set;}
    public string? Localidad { get; set;}
    public string? Nombre {get; set;} 
    public string? Apellido {get; set;}
    public string? Telefono {get; set;}
    public string? Direccion {get; set;}
    public bool Eliminado {get; set;}
    }