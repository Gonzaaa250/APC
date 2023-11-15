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
        var genero = Genero.Masculino;
        var usuarios = _context.Usuario.Where(u => u.Genero == genero).ToList();

        var usuarioBuscar = new Usuario { UsuarioId = 0, Nombre = "[Seleccione un Jugador]" };
        usuarios.Add(usuarioBuscar);
        ViewBag.UsuarioId = new SelectList(usuarios.OrderBy(u => u.Nombre), "UsuarioId", "Nombre");

        return View();
    }
    public IActionResult IndexF()
    {
        var genero = Genero.Femenino;
        var usuarios = _context.Usuario.Where(u => u.Genero == genero).ToList();

        var usuarioBuscar = new Usuario { UsuarioId = 0, Nombre = "[Seleccione un Jugador]" };
        usuarios.Add(usuarioBuscar);
        ViewBag.UsuarioId = new SelectList(usuarios.OrderBy(u => u.Nombre), "UsuarioId", "Nombre");
        return View();
    }


    public JsonResult BuscarRanking(int GeneroParametro = 1, int RankingId = 0)
    {
        //PRIMERO BUSCAMOS EL LISTADO DE CATEGORIAS Y LUEGO POR CADA UNA EL LISTADO DE JUGADORES 
        var categorias = _context.Categoria.Include(r => r.Usuario).OrderBy(c => c.Tipo).ToList();

        List<VistaRanking> rankingsMostrar = new List<VistaRanking>();

        foreach (var categoriaTabla in categorias)
        {
            //PRIMERO NOS ASEGURAMOS DE QUE LA CATEGORIA NO EXISTE EN EL LISTADO
            var categoria = rankingsMostrar.Find(c => c.CategoriaId == categoriaTabla.CategoriaId);
            if (categoria == null)
            {
                categoria = new VistaRanking
                {
                    CategoriaId = categoriaTabla.CategoriaId,
                    Tipo = categoriaTabla.Tipo,
                    ListadoJugadores = new List<ListadoUsuarios>()
                };
                rankingsMostrar.Add(categoria);
            }
            //BUSCO TODOS LOS USUARIOS DE ESA CATEGORIA
            var genero = Genero.Masculino;
            if (GeneroParametro != 1)
            {
                genero = Genero.Femenino;
            }

            var usuarios = _context.Usuario.Where(u => u.Genero == genero).ToList();
            foreach (var jugadorTabla in categoriaTabla.Usuario)
            {
                var usuarioabuscar = usuarios.Where(u => u.UsuarioId == jugadorTabla.UsuarioId).FirstOrDefault();
                if (usuarioabuscar != null)
                {
                    var clubAgregar = _context.Club.Where(r => r.ClubId == jugadorTabla.ClubId).Single();

                    var sumaPuntos = _context.Ranking.Where(j => j.UsuarioId == jugadorTabla.UsuarioId).Select(j => j.Puntos).Sum();

                    var jugador = new ListadoUsuarios
                    {
                        UsuarioId = jugadorTabla.UsuarioId,
                        Nombre = jugadorTabla.Nombre,
                        ClubNombre = clubAgregar.Nombre,
                        Puntos = sumaPuntos
                    };
                    categoria.ListadoJugadores.Add(jugador);
                }
            }

            categoria.ListadoJugadores = categoria.ListadoJugadores.OrderByDescending(p => p.Puntos).ToList();

        }
        rankingsMostrar = rankingsMostrar.OrderBy(r => r.Tipo).ToList();
        return Json(rankingsMostrar);
    }
    [Authorize(Roles = "Administrador")]
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


    [Authorize(Roles = "Administrador")]
    public IActionResult EliminarRanking(int RankingId, int Eliminado, int Puntos)
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

                // CORRECCIÓN: Establecer los puntos en 0 en lugar de intentar eliminar la propiedad Puntos
                ranking.Puntos = 0;
                _context.SaveChanges();
            }
            resultado = 1;
        }

        return Json(resultado);
    }
}

