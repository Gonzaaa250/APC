using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TesisPadel.Models;
public class Ranking
{
    public int RankingId { get; set; }

    // Propiedades para asociar el usuario y la categoría
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; }
    public int CategoriaId { get; set; }
    public int ClubId {get;set;}
    public bool Eliminado { get; set; }

    // Puntuación del usuario en esa categoría
    public int Puntos { get; set; }

    // Navegación a los modelos de Usuario y Categoria
    public virtual Categoria? Categoria { get; set; }
    public virtual Club? Club { get; set; }
    public virtual ICollection<Usuario>? Usuario { get; set; }
}
