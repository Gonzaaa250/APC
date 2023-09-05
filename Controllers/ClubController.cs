using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TesisPadel.Data;
using TesisPadel.Models;
namespace TesisPadel.Controllers;

[Authorize]
public class ClubController : Controller
{
    private readonly ILogger<ClubController> _logger;
    private readonly TesisPadelDbContext _context;
    public ClubController(ILogger<ClubController> logger, TesisPadelDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    // [Authorize(Roles = "Administrador")]
    public IActionResult Index()
    {
        var clubs = _context.Club.ToList();
        return View();
    }
    public JsonResult BuscarClub(int ClubId = 0)
    {
        var clubs = _context.Club.ToList();
        if (ClubId > 0)
        {
            clubs = clubs.Where(c => c.ClubId == ClubId).OrderBy(c => c.Nombre).ToList();
        }
        return Json(clubs);
    }
    // [Authorize(Roles = "Administrador")]
    public JsonResult GuardarClub(int ClubId, string Nombre, string Localidad, IFormFile imagen)
    {
        bool resultado = false;

        if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Localidad))
        {
            if (ClubId == 0)
            {
                var clubExistente = _context.Club.FirstOrDefault(c => c.Nombre == Nombre);

                if (clubExistente == null)
                {
                    var clubguardar = new Club
                    {
                        Nombre = Nombre,
                        Localidad = Localidad
                    };
                    if (imagen != null && imagen.Length > 0)
                    {
                        byte[] imagenBinaria = null;
                        using (var fs1 = imagen.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            imagenBinaria = ms1.ToArray();
                        }
                        clubguardar.Imagen = imagenBinaria;
                        clubguardar.TipoImagen = imagen.ContentType;
                    }
                
                    _context.Add(clubguardar);
                    _context.SaveChanges();
                    resultado = true;
                }
            }
            else
            {
                var clubExistente = _context.Club.FirstOrDefault(c => c.Nombre == Nombre && c.Localidad == Localidad && c.ClubId != ClubId);

                if (clubExistente == null)
                {
                    var clubeditar = _context.Club.Find(ClubId);

                    if (clubeditar != null)
                    {
                        clubeditar.Nombre = Nombre;
                        clubeditar.Localidad = Localidad;
                        if (imagen != null && imagen.Length>0 )
                        {
                            byte[] imagenBinaria=null ;
                            using (var fs2 = imagen.OpenReadStream() )
                            using (var ms3 =new MemoryStream())
                            {
                                fs2 . CopyTo(ms3 );
                                imagenBinaria = ms3. ToArray ();
                                }
                                clubeditar. Imagen = imagenBinaria;
                                clubeditar. TipoImagen = imagen. ContentType;
                                }
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            return Json(resultado);
        }
        return Json(resultado);
    }
    
    public JsonResult EliminarClub(int ClubId, int Eliminado)
    {
        int resultado = 0;
        var club = _context.Club.Find(ClubId);

        if (club != null)
        {
            if (Eliminado ==0)
            {
                club.Eliminado = false;
            _context.SaveChanges();
            }
            
            else{
                if (Eliminado == 1)
                {
                    club.Eliminado = true;
                    _context.Remove(club);
                    _context.SaveChanges();
                }
            }
        }
        resultado = 1;

        return Json(resultado);
    }
}