using System.ComponentModel.DataAnnotations;
namespace TesisPadel.Models;
public class Club{
  [Key]
    public int ClubId {get; set;}

    [Required(ErrorMessage="Este campo es obligatorio")]
    public string Nombre {get; set;}
    [Required(ErrorMessage="Este campo es obligatorio")]
    public string Localidad {get; set;}
    public bool Eliminado {get; set;}
}