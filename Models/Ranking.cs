using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesisPadel.Models;
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        
        public string Puntos { get; set; }
        
        public bool Eliminado { get; set; }
        
        public string Club { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
