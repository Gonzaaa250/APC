using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;
public class ClubsController : Controller{
    private readonly ILogger<ClubsController> _logger;
    private TesisPadelDbContext _contexto;
    public ClubsController(ILogger<ClubsController> logger, TesisPadelDbContext contexto){
        _logger = logger;
        _contexto = contexto;
    }
     public IActionResult Index()
    {
        return View();
    }
    public JsonResult BuscarClub(int ClubId= 0){
        var Club= _contexto.Club.ToList();
        if(ClubId >0){
            Club= Club.Where(c=> c.ClubId== ClubId).OrderBy(c=>c.Nombre).ToList();
        }
        return Json(Club);
    }
     public JsonResult GuardarClub(int ClubId, string Nombre){
        bool resultado= false;
        if(!string.IsNullOrEmpty(Nombre)){
            if(ClubId==0){
                var nuevoclub= _contexto.Club.Where(c=> c.Nombre== Nombre).FirstOrDefault();
                if(nuevoclub == null){
                    var guardarclub= new Club{
                        Nombre= Nombre
                    };
                    _contexto.Club.Add(guardarclub);
                    _contexto.SaveChanges();
                    resultado= true;
                    }
                    else {
                        var guardarclub= _contexto.Club.Where(c=> c.Nombre == Nombre && c.ClubId != ClubId).FirstOrDefault();
                        if(guardarclub == null){
                            var EditarClub= _contexto.Club.Find(ClubId);
                            if(EditarClub==null){
                                EditarClub.Nombre= Nombre;
                                _contexto.SaveChanges();
                                resultado= true;
                            }
                        }
                    }
                }
            }
           return Json(resultado);
        }
        public JsonResult EliminarClub(int ClubId, int Eliminado){
            int resultado= 0;
            var club= _contexto.Club.Find(ClubId);
                if(club== null){
                    if(Eliminado==0){
                        club.Eliminado= false;
                        _contexto.SaveChanges();
                    }
                    else{
                        if(Eliminado==1){
                            club.Eliminado= true;
                            _contexto.SaveChanges();
                        }
                    }
                 }
                resultado= 1;
                 return Json(resultado);
        }

}