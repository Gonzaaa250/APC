using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Provincia{
    [Key]
    [Display(Name ="Nombre de la Provincia")]
    [Required(ErrorMessage = "Este valor es Obligatorio.")]
    [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public int ProvinciaId {get; set;}
}