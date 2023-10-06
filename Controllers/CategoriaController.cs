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
using TesisPadel.Data;
using TesisPadel.Models;
namespace TesisPadel.Controllers;
[Authorize]
public class CategoriaController : Controller
{
    private readonly ILogger<CategoriaController> _logger;
    private ApplicationDbContext _context;
    public CategoriaController(ILogger<CategoriaController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var categoria = _context.Categoria.OrderBy(c => c.Tipo).ToList();
        return View();
    }
    public JsonResult BuscarCategoria(int CategoriaId)
    {
        var categorias = _context.Categoria.ToList();
        if (CategoriaId > 0)
        {
            categorias = categorias.Where(c => c.CategoriaId == CategoriaId).ToList();
        }
        else
        {
            categorias = categorias.OrderBy(c => c.Tipo).ToList();
        }
        return Json(categorias);
    }
    public JsonResult GuardarCategoria(int CategoriaId, string Tipo)
{
    bool result = false;

    if (!string.IsNullOrEmpty(Tipo))
    {
        if (CategoriaId == 0)
        {
            // Verificar si la categoría ya existe
            var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.Tipo == Tipo);

            if (categoriaExistente == null)
            {
                var nuevaCategoria = new Categoria
                {
                    Tipo = Tipo
                };

                _context.Add(nuevaCategoria);
                _context.SaveChanges();
                result = true;
            }
        }
        else
        {
            // Verificar si el Tipo ya existe en otra categoría
            var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.Tipo == Tipo && c.CategoriaId != CategoriaId);

            if (categoriaExistente == null)
            {
                var editarCategoria = _context.Categoria.Find(CategoriaId);

                if (editarCategoria != null)
                {
                    editarCategoria.Tipo = Tipo;

                    _context.SaveChanges();
                    result = true;
                }
            }
        }
    }

    return Json(result);
}

    public JsonResult EliminarCategoria(int CategoriaId)
    {
        bool result = false;

        if (CategoriaId != 0)
        {
            var categoria = _context.Categoria.Find(CategoriaId);

            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
                result = true;
            }
        }

        return Json(result);
    }
}

