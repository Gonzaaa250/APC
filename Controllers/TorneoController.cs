using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;
public class TorneoController: Controller{
    private readonly ILogger<TorneoController> _logger;
     private TesisPadelDbContext _contexto;
     public TorneoController(TesisPadelDbContext contexto, ILogger<TorneoController> logger){
        _contexto = contexto;
        _logger = logger;
     }
       public IActionResult Index()
    {
        return View();
    }
    
}