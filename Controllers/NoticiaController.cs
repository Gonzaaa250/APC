using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Data;
using TesisPadel.Models;
namespace TesisPadel.Controllers;
public class NoticiaController : Controller
{

    private readonly ApplicationDbContext _context;
    public NoticiaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public JsonResult GuardarNoticia(string Titulo, string Descripcion, int posicion, string Link, IFormFile imagen)
    {
        var NoticiaAGuardar = new Noticia();
        // Revisamos que esten todos estos datos
        if(Titulo != null && Descripcion != null && posicion != null && Link != null)
        {
            NoticiaAGuardar = new Noticia{
                Titulo = Titulo,
                Descripcion = Descripcion,
                posicion = posicion,
                Link = Link,
                Eliminado = false
            };
            //buscamos si existe una noticia en esa posicion
            var NoticiaActivaParaDesactivar = _context.Noticias.Where( N=> N.posicion == posicion && N.Eliminado == false).FirstOrDefault();
            //Sí existe Eliminarla de la portada
            if (NoticiaActivaParaDesactivar != null){
                NoticiaActivaParaDesactivar.Eliminado = true;
            }
            //Logica para guardar la imagen
            if (imagen != null && imagen.Length > 0)
            {
                byte[] imagenBinaria = null;
                using (var fs1 = imagen.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    imagenBinaria = ms1.ToArray();
                }
                NoticiaAGuardar.Imagen = imagenBinaria;
                NoticiaAGuardar.TipoImagen = imagen.ContentType;
            }else{
                return Json("Error: Tiene que cargar una imagen");
            }
            _context.Add(NoticiaAGuardar);
            _context.SaveChanges();
        }else{
            return Json("Error: Todos Los campos tienen que estar completados", Json(Link, Json(Titulo, Json(Link, Json(Descripcion, Json(posicion))))));
        }
        return Json(NoticiaAGuardar);
    }
}