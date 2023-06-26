using System.ComponentModel.DataAnnotations;

    namespace TesisPadel.Models;
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Puntos { get; set; }

        //Chekear si esta bien la relación
        //public virtual ICollection<Categoria>? Categorias {get; set;}


    }