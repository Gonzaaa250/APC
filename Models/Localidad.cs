using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Localidad{
   [Key]
    public int LocalidadId {get; set;}
    public string? LNombre {get; set;}
    public string? Provincia{get; set;}
}