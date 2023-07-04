using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;

    public class LocalidadController : Controller
    {
        private readonly ILogger<LocalidadController> _logger;
        private TesisPadelDbContext _context;
        public LocalidadController(ILogger<LocalidadController> logger, TesisPadelDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public JsonResult BuscarLocalidad(int LocalidadId = 0)
        {
            var localidad = _context.Localidad.ToList();
            if (LocalidadId > 0)
            {
                localidad = localidad.Where(l => l.LocalidadId == LocalidadId).OrderBy(l => l.LNombre).ToList();
            }
            return Json(localidad);
        }
        public JsonResult GuardarLocalidad(int LocalidadId, string LNombre)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(LNombre))
            {
                var Localidad1 = _context.Localidad.Where(l => l.LNombre == LNombre).FirstOrDefault();
                if (Localidad1 == null)
                {
                    var localidadguardar = new Localidad
                    {
                        LNombre = LNombre,
                    };
                    _context.Add(localidadguardar);
                    _context.SaveChanges();
                    resultado = true;
                }
            }
            else
            {
                var Localidad1 = _context.Localidad.Where(l => l.LNombre == LNombre && l.LocalidadId != LocalidadId).FirstOrDefault();
                if (Localidad1 == null)
                {
                    var localidadeditar = _context.Localidad.Find(LocalidadId);
                    if (localidadeditar != null)
                    {
                        localidadeditar.LNombre = LNombre;
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }
            return Json(resultado);
        }

    }

