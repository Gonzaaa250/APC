using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Club{
  [Key]
    public int ClubId {get; set;}
    public string? Nombre {get; set;}
    public string? Direccion {get; set;}
    public bool Eliminado {get; set;}
    public virtual Localidad? Localidad {get; set;}
}