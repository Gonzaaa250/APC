// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace TesisPadel.Models;
// public class Jugador {
//     [Key]
//     public int JugadorId {get; set;}
//     [Display(Name ="Nombre")]
//     [Required(ErrorMessage = "Este valor es Obligatorio.")]
//     [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
//     public string? NombreJUgador {get; set;}
//     [Display(Name ="Apellido")]
//     [Required(ErrorMessage = "Este valor es Obligatorio.")]
//     [MaxLength(150, ErrorMessage = "El largo maximo es de {0} caracteres.")]
//     public string? ApellidoJugador {get; set;}
   
//     [Display(Name = "Fecha de Nacimiento")]
//         [DataType(DataType.Date)]
//         public DateTime JugadorBirthDate { get; set; }


//         [NotMapped]
//         public int JugadorAge 
//         {
//             get
//             {
//                 return DateTime.Now.Year - JugadorBirthDate.Year;
//             } 
//         }
//     public string? Telefono {get; set;}
//     public string? DNI {get; set;}

//     public int LocalidadId {get; set;} 
//      public bool Eliminado {get; set;}
//      public virtual Localidad? Localidad {get; set;}
// }
