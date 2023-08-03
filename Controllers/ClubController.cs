using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers
{
    public class ClubController : Controller
    {
        private readonly ILogger<ClubController> _logger;
        private TesisPadelDbContext _context;

        public ClubController(ILogger<ClubController> logger, TesisPadelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var clubs = _context.Club.ToList();
            return View(clubs);
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

        public JsonResult GuardarClub(int ClubId, string Nombre, string Direccion)
        {
            bool resultado = false;

            if (!string.IsNullOrEmpty(Nombre))
            {
                if (ClubId == 0)
                {
                    var clubExistente = _context.Club.FirstOrDefault(c => c.Nombre == Nombre);

                    if (clubExistente == null)
                    {
                        var clubguardar = new Club
                        {
                            Nombre = Nombre
                            
                        };
                        _context.Add(clubguardar);
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
                else
                {
                    var clubExistente = _context.Club.FirstOrDefault(c => c.Nombre == Nombre && c.ClubId != ClubId);

                    if (clubExistente == null)
                    {
                        var clubeditar = _context.Club.Find(ClubId);

                        if (clubeditar != null)
                        {
                            clubeditar.Nombre = Nombre;
                            _context.SaveChanges();
                            resultado = true;
                        }
                    }
                }
            }

            return Json(resultado);
        }

        public JsonResult EliminarClub(int ClubId, int Eliminado)
        {
            int resultado = 0;
            var club = _context.Club.Find(ClubId);

            if (club != null)
            {
                club.Eliminado = Eliminado == 1;
                _context.SaveChanges();
            }

            resultado = 1;
            return Json(resultado);
        }
    }
}

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
// public class ClubController : Controller
// {
//     private readonly ILogger<ClubController> _logger;
//     private TesisPadelDbContext _context;
//     public ClubController(ILogger<ClubController> logger, TesisPadelDbContext context)
//     {
//         _logger = logger;
//         _context = context;
//     }
//     public IActionResult Index()
//     {
//         return View();
//     }
//     public JsonResult BuscarClub(int ClubId=0){
//         var club= _context.Club.ToList();
//         if (ClubId>0){
//             club= club.Where(c=> c.ClubId== ClubId).OrderBy(c=> c.Nombre).ToList();
//         }
//         return Json(club);
//     }
//     public JsonResult GuardarClub(int ClubId, string Nombre, string Direccion)
//     {
//         bool resultado= false;
//         if (!string.IsNullOrEmpty(Nombre))
//         {
//             if(ClubId==0){
//                 var Club1= _context.Club.Where(c=> c.Nombre== Nombre && c.Direccion==Direccion).FirstOrDefault();
//                 if(Club1==null){
//                     var clubguardar= new Club{
//                         Nombre= Nombre,
//                         Direccion= Direccion
//                     };
//                     _context.Add(clubguardar);
//                     _context.SaveChanges();
//                     resultado= true ;
//                 }
//             }
//             else{
//                 var Club1= _context.Club.Where(c=> c.Nombre== Nombre && c.ClubId!=ClubId && c.Direccion== Direccion).FirstOrDefault();
//                 if (Club1==null){
//                     var clubeditar=_context.Club.Find(ClubId);
//                     if(clubeditar!= null){
//                         clubeditar.Nombre=Nombre;
//                         clubeditar.Direccion = Direccion;
//                         _context.SaveChanges();
//                         resultado=true;
//                     }
//                 }
//             }
//         }
//         return Json(resultado);
//     }
//     public JsonResult EliminarClub(int ClubId, int Eliminado){
//         int resultado=0;
//         var club= _context.Club.Find(ClubId);
//         if(club !=null){
//             if(Eliminado==0)
//             {
//                 club.Eliminado= false;
//                 _context.SaveChanges();
//             }
//             else{
//                 if(Eliminado==1){
//                     club.Eliminado= true;
//                     _context.SaveChanges();
//                 }
//             }
//         }
//         resultado = 1;

//         return Json(resultado);
//     }
// }