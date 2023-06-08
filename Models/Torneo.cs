using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models{
    public class Torneo{ 
        [Key]
        public int TorneoId {get; set;}
       [Display(Name ="Categoria")]
       [Required(ErrorMessage ="Este valor es obligatorio")]
       [MaxLength(50, ErrorMessage ="El valor maximo es de{0} caracteres")]
        public string? Categoria {get; set;}
        [Display(Name ="Fecha")]
       [DataType(DataType.Date)]
        public DateTime? Fecha {get; set;}

        public virtual ICollection<Jugador>? Jugador {get; set;}
    }
}