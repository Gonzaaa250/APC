using System.ComponentModel.DataAnnotations;

    namespace TesisPadel.Models;
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puntos { get; set; }
        public string Club {get; set;}
    public virtual ICollection<Categoria>? Categorias {get; set;}
    public virtual Usuario? Usuario {get; set;}

    }