using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Club{
  [Key]
    public int ClubId {get; set;}
    [Display(Name="Nombre del club")]
     [Required(ErrorMessage = "Este valor es Obligatorio.")]
     [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Nombre {get; set;}
    [Display(Name ="Direccion")]
     [Required(ErrorMessage = "Este valor es Obligatorio.")]
    [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Direccion {get; set;}
    public bool Eliminado {get; set;}
    public virtual ICollection<Localidad>? Localidad {get; set;}
    // public virtual ICollection<Categoria>? Categoria {get; set;}
}