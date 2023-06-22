using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;
public class JugadoresController: Controller{
    private readonly ILogger<JugadoresController> _logger;
    private TesisPadelDbContext _contexto;
    public JugadoresController(TesisPadelDbContext contexto, ILogger<JugadoresController> logger){
          _logger = logger;
        _contexto = contexto;
    }
     public IActionResult Index()
    {
        return View();
    }
    public JsonResult BuscarJugador(int JugadorId=0){
        var Jugador= _contexto.Jugadores.ToList();
        if (JugadorId>0){
            Jugador= Jugador.Where(j=> j.JugadorId == JugadorId).OrderBy(j=> j.Nombre).ToList();
        }
        return Json(Jugador);
    }
    public JsonResult GuardarJugador(int JugadorId, string Nombre){
        bool resultado= false;
        if (!string.IsNullOrEmpty(Nombre)){
            if(JugadorId==0){
                var nuevojugador= _contexto.Jugadores.Where(j=> j.Nombre == Nombre).FirstOrDefault();
                if(nuevojugador== null){
                    var guardarjugador= new Jugador{
                        Nombre= Nombre
                    };
                    _contexto.Jugadores.Add(guardarjugador);
                    _contexto.SaveChanges();
                    resultado= true;
                }
                else{
                    var guardarjugador= _contexto.Jugadores.Where(j=> j.Nombre== Nombre && j.JugadorId != JugadorId).FirstOrDefault();
                    if(guardarjugador == null){
                            var EditarJugador= _contexto.Jugadores.Find(JugadorId);
                            if(EditarJugador==null){
                                EditarJugador.Nombre= Nombre;
                                _contexto.SaveChanges();
                                resultado= true;
                            }
                        }
                    }
                }
            }
             return Json(resultado);
    }
   
    public JsonResult EliminarJugador(int JugadorId, int Eliminado){
         int resultado= 0;
            var jugador= _contexto.Jugadores.Find(JugadorId);
                if(jugador== null){
                    if(Eliminado==0){
                        jugador.Eliminado= false;
                        _contexto.SaveChanges();
                    }
                    else{
                        if(Eliminado==1){
                            jugador.Eliminado= true;
                            _contexto.SaveChanges();
                        }
                    }
                 }
                resultado= 1;
                 return Json(resultado);
    }
}