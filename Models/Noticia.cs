using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesisPadel.Models;

public class Noticia
{
    [Key]
    public int NoticiaId { get; set; }
    public byte[]? Imagen { get; set; }
    public string TipoImagen { get; set; }

    [NotMapped]
    public string ImagenBase64{get{if (Imagen != null)
    {return Convert.ToBase64String(Imagen);}else{return "";}}
    }

    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Link {get; set;}
    public int posicion {get; set;}
    public bool Eliminado {get; set;}
    }
