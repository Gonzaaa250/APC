using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers
{
    public class RankingController : Controller
    {
        private readonly ILogger<RankingController> _logger;
        private readonly TesisPadelDbContext _context;

        public RankingController(ILogger<RankingController> logger, TesisPadelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var rankings = _context.Ranking.ToList();
            return View();
        }
        public JsonResult BuscarRanking(int RankingId = 0)
        {
            var rankings = _context.Ranking.ToList();
            if (RankingId > 0)
            {
                rankings = rankings
                    .Where(r => r.RankingId == RankingId)
                    .OrderBy(r => r.Usuario.Nombre)
                    .ToList();
            }
            return Json(rankings);
        }

        public JsonResult GuardarRanking(
            int RankingId,
            string Puntos,
            string Club,
            string Categoria,
            string Nombre,
            string Localidad
        )
        {
            bool resultado = false;

            if (!string.IsNullOrEmpty(Nombre)
                && !string.IsNullOrEmpty(Club)
                && !string.IsNullOrEmpty(Puntos))
            {
                if (RankingId == 0)
                {
                    var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre);
                    if (usuarioExistente != null)
                    {
                        var rankingGuardar = new Ranking
                        {
                            Usuario = usuarioExistente,
                            Club = Club,
                            Puntos = Puntos
                        };

                        _context.Add(rankingGuardar);
                        _context.SaveChanges();
                        resultado = true;
                    }
                }
                else
                {
                    var rankingEditar = _context.Ranking.Find(RankingId);
                    if (rankingEditar != null && rankingEditar.Usuario.Nombre == Nombre)
                    {
                        rankingEditar.Club = Club;
                        rankingEditar.Puntos = Puntos;

                        _context.SaveChanges();
                        resultado = true;
                    }
                }
            }

            return Json(resultado);
        }

        public IActionResult EliminarRanking(int RankingId, int Eliminado)
        {
            int resultado = 0;
            var ranking = _context.Ranking.Find(RankingId);
            if (ranking != null)
            {
                if (Eliminado == 0)
                {
                    ranking.Eliminado = false;
                    _context.SaveChanges();
                }
                else if (Eliminado == 1)
                {
                    ranking.Eliminado = true;
                    _context.Remove(ranking);
                    _context.SaveChanges();
                }
                resultado = 1;
            }

            return Json(resultado);
        }
    }
}
