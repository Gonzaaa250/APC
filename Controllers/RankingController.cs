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
            var usuario = _context.Usuario?.ToList();
            ViewBag.UsuarioId = new SelectList(usuario, "UsuarioId", "Nombre");
            var club = _context.Club?.ToList();
            ViewBag.ClubId = new SelectList(club, "ClubId", "Nombre");
            var categoria= _context.Categoria?.ToList();
            ViewBag.CategoriaId = new SelectList(categoria, "CategoriaId", "Tipo");
            return View();
        }
        public JsonResult BuscarRanking(int RankingId = 0)
        {
            var rankings = _context.Ranking.Include(r=> r.Categoria).ToList();
            if (RankingId > 0)
            {
                rankings = rankings.Where(r => r.RankingId == RankingId).OrderBy(r => r.UsuarioNombre).ToList();
            }
            rankings = rankings.OrderBy(r=> r.Categoria.Tipo).ThenBy(r=> r.UsuarioNombre).ToList();
            return Json(rankings);
        }

        public JsonResult GuardarRanking(int RankingId, int Puntos, int ClubId, string Categoria, string UsuarioNombre, int UsuarioId, int CategoriaId)
        {
            bool resultado = false;

            if (!string.IsNullOrEmpty(UsuarioNombre))
            {
                if (RankingId == 0)
                {
                    var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Nombre == UsuarioNombre);
                    if (usuarioExistente == null)
                    {
                        var categoria =_context.Categoria.FirstOrDefault(c=> c.CategoriaId == CategoriaId);
                        var club = _context.Club.FirstOrDefault(c => c.ClubId == ClubId);
                        if(categoria != null)
                        {
                        var rankingGuardar = new Ranking
                        {
                            UsuarioNombre = usuarioExistente.Nombre,
                            Puntos = Puntos,
                            Club = club,
                            Categoria = categoria
                        };

                        _context.Add(rankingGuardar);
                        _context.SaveChanges();
                        resultado = true;
                        }
                    }
                }
                else
                {
                    var rankingEditar = _context.Ranking.Find(RankingId);
                    if (rankingEditar != null && rankingEditar.UsuarioNombre == UsuarioNombre)
                    {
                        rankingEditar.Puntos = Puntos;
                        rankingEditar.Categoria =_context.Categoria.FirstOrDefault(c=> c.CategoriaId == CategoriaId);
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
