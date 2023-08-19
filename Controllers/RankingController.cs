// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using TesisPadel.Data;
// using TesisPadel.Models;

// namespace TesisPadel.Controllers;

// public class RankingController : Controller
// {
//     private readonly ILogger<RankingController> _logger;
//     private TesisPadelDbContext _context;

//     public RankingController(ILogger<RankingController> logger, TesisPadelDbContext context)
//     {
//         _logger = logger;
//         _context = context;
//     }

//     public IActionResult Index()
//     {
//         var ranking = _context.Ranking.ToList();
//         return View();
//     }

//     public JsonResult BuscarRanking(int RankingId = 0)
//     {
//         var rankings = _context.Ranking.ToList();
//         if (RankingId > 0)
//         {
//             rankings = rankings.Where(r => r.RankingId == RankingId).OrderBy(r => r.Nombre).ToList();
//         }
//         return Json(rankings);
//     }

//     public JsonResult GuardarRanking(
//     int RankingId,
//     string Puntos,
//     string Club,
//     string Categoria,
//     string Nombre,
//     string Localidad
// )
// {
//     bool resultado = false;

//     if (!string.IsNullOrEmpty(Nombre)
//         && !string.IsNullOrEmpty(Localidad)
//         && !string.IsNullOrEmpty(Club)
//         && !string.IsNullOrEmpty(Puntos))
//     {
//         if (RankingId == 0)
//         {
//             var rankingExistente = _context.Ranking.FirstOrDefault(r => u.Nombre == Nombre);
//             if (rankingExistente == null)
//             {
//                 var rankingGuardar = new Ranking
//                 {
//                     Nombre = Nombre,
//                     Localidad = Localidad,
//                     Club = Club,
//                     Puntos = Puntos,
//                     rankingGuardar.Categorias = Categorias,

//                 };

//                 _context.Add(rankingGuardar);
//                 _context.SaveChanges();
//                 resultado = true;
//             }
//         }
//         else
//         {
//             var rankingExistente = _context.Ranking.FirstOrDefault(r => r.RankingId == RankingId && r.Nombre != Nombre);
//             if (rankingExistente == null)
//             {
//                 var rankingEditar = _context.Ranking.Find(RankingId);
//                 if (rankingEditar != null)
//                 {
//                     rankingEditar.Nombre = Nombre;
//                     rankingEditar.Localidad = Localidad;
//                     rankingEditar.Club = Club;
//                     rankingEditar.Puntos = Puntos;
//                     rankingEditar.Categorias= Categorias;

//                     _context.SaveChanges();
//                     resultado = true;
//                 }
//             }
//         }
//     }
    
//     return Json(resultado);
// }

//     public IActionResult EliminarRanking(int RankingId, int Eliminado)
//     {
//         int resultado = 0;
//         var ranking = _context.Ranking.Find(RankingId);
//         if(ranking !=null){
//             if(Eliminado ==0)
//             {
//                 ranking.Eliminado = false;
//                 _context.SaveChanges() ;
//             }
//             else
//             {
//                 if(Eliminado ==1)
//                 {
//                     ranking.Eliminado= true;
//                     _context.Remove(ranking);
//                     _context.SaveChanges();
//                 }
//             }
//             resultado =1;
//         }
        
//         return Json(resultado);
//     }
// }
