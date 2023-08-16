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

public class RankingController : Controller
{
    private readonly ILogger<RankingController> _logger;
    private TesisPadelDbContext _context;

    public RankingController(ILogger<RankingController> logger, TesisPadelDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var ranking = _context.Ranking.ToList();
        return View();
    }

    public JsonResult BuscarRanking(int RankingId = 0)
    {
        var rankings = _context.Ranking.ToList();
        if (RankingId > 0)
        {
            rankings = rankings
                .Where(r => r.RankingId == RankingId)
                .OrderBy(r => r.Nombre)
                .ToList();
        }
        return Json(rankings);
    }

    public JsonResult GuardarRanking(int RankingId, string Nombre, string Apellido, string Club, string Puntos){
        bool resultado = false;
        if(!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido) && !string.IsNullOrEmpty(Club) && !string.IsNullOrEmpty(Puntos)){
            if (RankingId ==0)
            {
                var rankingE = _context.Ranking.FirstOrDefault(r=> r.Nombre == Nombre);
                if (rankingE == null)
                {
                    var rankingguardar= new Ranking
                    {
                        Nombre = Nombre,
                        Apellido = Apellido,
                        Club = Club,
                        Puntos = Puntos
                    };
                    _context.Add(rankingguardar);
                    _context.SaveChanges();
                    resultado= true;
                }
            }
            else
            {
                var rankingE = _context.Ranking.FirstOrDefault(r => r.RankingId== RankingId && r.Nombre != Nombre );
                if(rankingE ==null)
                {
                    var rankingeditar = _context.Ranking.Find(RankingId);
                    if (rankingeditar != null)
                    {
                        rankingeditar.Nombre = Nombre;
                        rankingeditar.Apellido = Apellido;
                        rankingeditar.Club = Club;
                        rankingeditar.Puntos = Puntos;
                        _context.SaveChanges();
                        resultado =true;
                    }
                }
            }
        }
        return Json(resultado);
    }
    // public IActionResult EliminarRanking(int RankingId, int e)
}
