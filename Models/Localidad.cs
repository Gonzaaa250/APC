using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Localidad{
   [Key]
    public int LocalidadId {get; set;}
    public string? LocalidadNombre {get; set;}
    public virtual Provincia? Provincia{get; set;}
}