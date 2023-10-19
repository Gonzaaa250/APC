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
using System.Dynamic;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;

[Authorize]
public class RankingController : Controller
{
    private readonly ILogger<RankingController> _logger;
    private readonly ApplicationDbContext _context;

    public RankingController(ILogger<RankingController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var usuarios = _context.Usuario?.ToList();

        var usuarioBuscar = new Usuario { UsuarioId = 0, Nombre = "[Seleccione un Jugador]" };
        usuarios.Add(usuarioBuscar);
        ViewBag.UsuarioId = new SelectList(usuarios.OrderBy(u => u.Nombre), "UsuarioId", "Nombre");

        return View();
    }
    public IActionResult IndexF()
    {
        return View();
    }
    public JsonResult BuscarRanking(int RankingId = 0)
    {
        var rankings = _context.Ranking.Include(r => r.Usuario).ToList();
        if (RankingId > 0)
        {
            rankings = rankings.Where(r => r.RankingId == RankingId).ToList();
        }
        rankings = rankings.OrderBy(r => r.Usuario.Nombre).ToList();


        List<VistaRanking> rankingsMostrar = new List<VistaRanking>();
        foreach (var ranking in rankings)
        {
            //PRIMERO NOS ASEGURAMOS DE QUE LA CATEGORIA NO EXISTE EN EL LISTADO
            var categoria = rankingsMostrar.Find(c => c.CategoriaId == ranking.Usuario.CategoriaId);
            if (categoria == null)
            {
                var categoriaAgregar = _context.Categoria.Where(r => r.CategoriaId == ranking.Usuario.CategoriaId).Single();
                categoria = new VistaRanking
                {
                    CategoriaId = ranking.Usuario.CategoriaId,
                    Tipo = categoriaAgregar.Tipo,
                    ListadoJugadores = new List<ListadoUsuarios>()
                };
                rankingsMostrar.Add(categoria);
            }

            //luego revisamos si el usuario no existe
            var jugador = categoria.ListadoJugadores.Find(j => j.UsuarioId == ranking.UsuarioId);
            if (jugador == null)
            {
                var clubAgregar = _context.Club.Where(r => r.ClubId == ranking.Usuario.ClubId).Single();

                jugador = new ListadoUsuarios
                {
                    Nombre = ranking.Usuario.Nombre,
                    ClubNombre = clubAgregar.Nombre,
                    Puntos = ranking.Puntos
                };
                categoria.ListadoJugadores.Add(jugador);
            }
            else
            {
                jugador.Puntos += ranking.Puntos;
            }
        }

        return Json(rankingsMostrar);
    }

    public JsonResult GuardarRanking(int RankingId, int Puntos, int UsuarioId)
    {
        bool resultado = false;

        if (UsuarioId > 0)
        {
            if (RankingId == 0)
            {
                var rankingGuardar = new Ranking
                {
                    UsuarioId = UsuarioId,
                    Puntos = Puntos
                };
                _context.Add(rankingGuardar);
                _context.SaveChanges();

                resultado = true;
            }
            else
            {
                var rankingEditar = _context.Ranking.Find(RankingId);
                if (rankingEditar != null)
                {
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
