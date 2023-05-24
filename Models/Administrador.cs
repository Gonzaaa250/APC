using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
public class Administrador{
    [Key]
    public int AdministradorId {get; set;}
    public int UsuarioId {get; set;}

    public virtual Usuario? Usuario {get; set;}
}