using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Dynamic;
using TesisPadel.Data;
using TesisPadel.Models;
namespace TesisPadel.Controllers;

[Authorize]
public class NoticiaController : Controller
{

    private readonly ILogger<NoticiaController> _logger;
    private ApplicationDbContext _context;
    public NoticiaController(ILogger<NoticiaController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var noticias = _context.Noticias.Where(n => n.Eliminado == false).OrderBy(n => n.posicion).ToList();
        return View(noticias);
    }

    public JsonResult GuardarNoticia(string Titulo, string Descripcion, int posicion, string Link, IFormFile imagen)
    {
        var NoticiaAGuardar = new Noticia();
        if (Titulo != null && Descripcion != null && posicion != null && Link != null)
        {
            NoticiaAGuardar = new Noticia
            {
                Titulo = Titulo,
                Descripcion = Descripcion,
                posicion = posicion,
                Link = Link,
                Eliminado = false
            };
            var NoticiaActivaParaDesactivar = _context.Noticias.Where(N => N.posicion == posicion && N.Eliminado == false).FirstOrDefault();
            if (NoticiaActivaParaDesactivar != null)
            {
                NoticiaActivaParaDesactivar.Eliminado = true;
            }
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
            }
            _context.Add(NoticiaAGuardar);
            _context.SaveChanges();
        }
        return Json(NoticiaAGuardar);
    }
}