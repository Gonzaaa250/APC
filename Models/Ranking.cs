using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        public string Nombre {get; set;}
        public string Puntos { get; set; }
        public string Categoria {get; set;}
        public int UsuarioId {get; set;}
        public string UsuarioNombre { get; set; }
        public int ClubId {get; set;}
        public bool Eliminado { get; set; }
    }
