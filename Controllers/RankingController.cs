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
    public class RankingController : Controller{
        private readonly ILogger<RankingController> _logger;
        private TesisPadelDbContext _context;
        public RankingController(ILogger<RankingController> logger, TesisPadelDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    // public JsonResult 
    }
}
