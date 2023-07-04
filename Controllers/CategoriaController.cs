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
    public class CategoriaController : Controller
    {
       private readonly ILogger<CategoriaController> _logger;
       private TesisPadelDbContext _context;
       public CategoriaController(ILogger<CategoriaController> logger, TesisPadelDbContext context){
        _logger= logger;
        _context= context;
       }
       public IActionResult index(){
        return View();
       }
         public JsonResult BuscarCategoria(int CategoriaId=0){
        var categoria= _context.Categoria.ToList();
        if (CategoriaId>0){
            categoria= categoria.Where(c=> c.CategoriaId== CategoriaId).OrderBy(c=> c.genero).ToList();
        }
        return Json(categoria);
    }
    // public JsonResult GuardarCategoria(int CategoriaId, Genero genero){
    //        bool resultado = false;
    //   if (){}
                
    //  }
    }

