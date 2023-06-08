using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models;
public class Jugador {
    [Key]
    public int JugadorId {get; set;}
    [Display(Name ="Nombre")]
    [Required(ErrorMessage = "Este valor es Obligatorio.")]
    [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Nombre {get; set;}
    [Display(Name ="Apellido")]
    [Required(ErrorMessage = "Este valor es Obligatorio.")]
    [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Apellido {get; set;}
   
    [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime PartnerBirthDate { get; set; }


        [NotMapped]
        public int PartnerAge 
        {
            get
            {
                return DateTime.Now.Year - PartnerBirthDate.Year;
            } 
        }
    [Display(Name ="Localidad")]
    [Required(ErrorMessage = "Este valor es Obligatorio.")]
    [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Localidad {get; set;}
   
    [Display(Name ="Direccion")]
    [Required(ErrorMessage = "Este valor es Obligatorio.")]
     [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
    public string? Direccion {get; set;}
     public bool Eliminado {get; set;}
}
