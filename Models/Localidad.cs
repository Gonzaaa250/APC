using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Localidad{
   [Key]
    public int LocalidadId {get; set;}
    [Display(Name ="Nombre de la localidad")]
    [MaxLength(100, ErrorMessage = "Este valor es Obligatorio.")]
    public string? LNombre {get; set;}
    public virtual Provincia? Provincia{get; set;}
}