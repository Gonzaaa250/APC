using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria")]
        public string Localidad { get; set; }
        public byte[]? Imagen {get;set;}
        public string? TipoImagen {get; set;}
        public bool Eliminado { get; set; }
        [NotMapped]
        public string? ImagenBase64 {get; set;}
    }
}