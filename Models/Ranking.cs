using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TesisPadel.Models;
public class Ranking
{
    public int RankingId { get; set; }
    public int UsuarioId { get; set; }
    public bool Eliminado { get; set; } 
    public int Puntos { get; set; }
    public virtual Usuario? Usuario { get; set; }
}


public class VistaRanking
{
    public int CategoriaId { get; set; }
     public string Tipo { get; set; } 

     public List<ListadoUsuarios> ListadoJugadores { get; set; }
}
