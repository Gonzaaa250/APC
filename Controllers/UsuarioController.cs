using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly TesisPadelDbContext _context;

        public UsuarioController(ILogger<UsuarioController> logger, TesisPadelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuario.ToList();
            return View(usuarios); // Se debe pasar la lista de usuarios a la vista
        }

        public JsonResult BuscarUsuario(int UsuarioId = 0)
        {
            var usuarios = _context.Usuario.ToList();
            if (UsuarioId > 0)
            {
                usuarios = usuarios.Where(u => u.UsuarioId == UsuarioId).OrderBy(u => u.Nombre).ToList();
            }
            return Json(usuarios);
        }

        public JsonResult GuardarUsuario(int UsuarioId, string Nombre, string Apellido, string Localidad, string Telefono, string DNI, DateTime Edad, string Categoria)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Localidad) && !string.IsNullOrEmpty(Telefono)
                && !string.IsNullOrEmpty(DNI))
            {
                if (UsuarioId == 0)
                {
                    var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre);
                    if (usuarioExistente == null)
                    {
                        var usuarioguardar = new Usuario
                        {
                            Nombre = Nombre,
                            Localidad = Localidad,
                            Edad = Edad,
                            Telefono = Telefono,
                            DNI = DNI,
                        };
                        _context.Add(usuarioguardar);
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            return Json(resultado); 
        }
        public JsonResult EliminarUsuario(int UsuarioId, int Eliminado)
        {
            int resultado =0;
            var usuario = _context.Usuario.Find(UsuarioId);
            if(usuario != null)
            {
                if(Eliminado == 0)
                {
                    usuario.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    if(Eliminado ==1)
                    {
                        usuario.Eliminado = true;
                        _context.Remove(usuario);
                        _context.SaveChanges();
                    }
                }
            }
            resultado=1;
            return Json(resultado);
        }
    }
