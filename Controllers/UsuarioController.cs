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
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public UsuarioController(ILogger<UsuarioController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    // [Authorize(Roles = "Administrador")]
    public IActionResult Index()
    {
        var club = _context.Club.OrderBy(c => c.Nombre).ToList();
        ViewBag.ClubId = new SelectList(club, "ClubId", "Nombre");
        var categoria = _context.Categoria.OrderBy(c=> c.Tipo).ToList();
        ViewBag.CategoriaId = new SelectList(categoria, "CategoriaId", "Tipo");
        return View();
    }


    public JsonResult BuscarUsuario(int UsuarioId = 0)
    {
        var usuarios = _context.Usuario.Include(u => u.Club).Include(u => u.Categoria).ToList();

        if (UsuarioId > 0)
        {
            usuarios = usuarios.Where(u => u.UsuarioId == UsuarioId).OrderBy(u => u.Nombre).ToList();
        }
        else
        {
            usuarios = usuarios.OrderBy(u => u.Nombre).ToList();
        }

        List<ListadoUsuarios> usuariosMostrar = new List<ListadoUsuarios>();
        foreach (var usuario in usuarios)
        {
            // var Categoria = _context.Categoria.Where(c = c.CategoriaId == usuario.CategoriaId).FirstOrDefault();

            
            var usuarioMostrar = new ListadoUsuarios
            {
                UsuarioId = usuario.UsuarioId,
                Localidad = usuario.Localidad,
                Nombre = usuario.Nombre,
                Telefono = usuario.Telefono,
                DNI = usuario.DNI,
                Genero = usuario.Genero,
                categoriaNombre = usuario.Categoria.Tipo,
                ClubNombre = usuario.Club.Nombre
            };
            usuariosMostrar.Add(usuarioMostrar);
        }

        return Json(usuariosMostrar);
    }


    public JsonResult GuardarUsuario(int UsuarioId, string Nombre, string Localidad, string Telefono, string DNI, Genero Genero, int ClubId, int CategoriaId)
    {
        bool resultado = false;

        if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Localidad) && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(DNI))
        {
            if (UsuarioId == 0)
            {
                var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre);
                if (usuarioExistente == null)
                {
                    var club = _context.Club.FirstOrDefault(c => c.ClubId == ClubId); // Obtener el club por su ID
                    var categoria =_context.Categoria.FirstOrDefault(c=> c.CategoriaId == CategoriaId);
                    if (club != null)
                    {
                        
                            var usuarioguardar = new Usuario
                        {
                            Nombre = Nombre,
                            Localidad = Localidad,
                            Telefono = Telefono,
                            DNI = DNI,
                            Genero = Genero,
                            Club = club,
                            Categoria = categoria
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
                        usuarioActualizar.Categoria = _context.Categoria.FirstOrDefault(c=> c.CategoriaId == CategoriaId);
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
