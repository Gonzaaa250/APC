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

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly TesisPadelDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public UsuarioController(ILogger<UsuarioController> logger, TesisPadelDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    // [Authorize(Roles = "Administrador")]
    public IActionResult Index()
    {
        var club = _context.Club?.ToList();
        ViewBag.ClubId = new SelectList(club, "ClubId", "Nombre");
        return View();
    }

    public async Task<JsonResult> BuscarUsuario(int UsuarioId = 0)
    {
        var usuarios = _context.Usuario.ToList();
        if (UsuarioId > 0)
        {
            usuarios = usuarios.Where(u => u.UsuarioId == UsuarioId).OrderBy(u => u.Nombre).ToList();
        }
        return Json(usuarios);
        
    }

    public JsonResult GuardarUsuario(int UsuarioId, string Nombre, string Localidad, string Telefono, string DNI, Genero Genero, int ClubId, string Categoria)
    {
        bool resultado = false;

        if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Localidad) && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(DNI) && !string.IsNullOrEmpty(Categoria))
        {
            if (UsuarioId == 0)
            {
                var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre);
                if (usuarioExistente == null)
                {
                    var club = _context.Club.FirstOrDefault(c => c.ClubId == ClubId); // Obtener el club por su ID
                    if (club != null)
                    {
                        var usuarioguardar = new Usuario
                        {
                            Nombre = Nombre,
                            Localidad = Localidad,
                            Telefono = Telefono,
                            DNI = DNI,
                            Genero = Genero,
                            Categoria = Categoria,
                            Club = club 
                        };
                        _context.Add(usuarioguardar);
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            else
            {
                var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre && u.Localidad == Localidad && u.UsuarioId != UsuarioId);
                if (usuarioExistente == null)
                {
                    var usuarioActualizar = _context.Usuario.Include(u => u.Club).FirstOrDefault(u => u.UsuarioId == UsuarioId);
                    if (usuarioActualizar != null)
                    {
                        usuarioActualizar.Nombre = Nombre;
                        usuarioActualizar.Localidad = Localidad;
                        usuarioActualizar.Telefono = Telefono;
                        usuarioActualizar.DNI = DNI;
                        usuarioActualizar.Genero = Genero;
                        usuarioActualizar.Categoria = Categoria;
                        usuarioActualizar.Club = _context.Club.FirstOrDefault(c => c.ClubId == ClubId); // Actualizar el objeto Club al usuario
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }
        }

        return Json(resultado);
    }

    public JsonResult EliminarUsuario(int UsuarioId, int Eliminado)
    {
        int resultado = 0;
        var usuario = _context.Usuario.Find(UsuarioId);
        if (usuario != null)
        {
            if (Eliminado == 0)
            {
                usuario.Eliminado = false;
                _context.SaveChanges();
            }
            else
            {
                if (Eliminado == 1)
                {
                    usuario.Eliminado = true;
                    _context.Remove(usuario);
                    _context.SaveChanges();
                }
            }
        }
        resultado = 1;
        return Json(resultado);
    }
}
