using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> rolManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;  // Corregido
            _rolManager = rolManager;    // Corregido
        }

        public async Task<IActionResult> Index()
        {
            await InicializarPermisosUsuario();
            return View();
        }

        public async Task<JsonResult> InicializarPermisosUsuario()
        {
            // CREAR ROLES SI NO EXISTEN
            if (!_context.Roles.Any(r => r.Name == "Administrador"))
            {
                var roleResult = await _rolManager.CreateAsync(new IdentityRole("Administrador"));
            }

            // CREAR USUARIO PRINCIPAL
            bool creado = false;

            // BUSCAR POR MEDIO DE CORREO ELECTRÓNICO SI EXISTE EL USUARIO
            var usuario = await _userManager.FindByEmailAsync("Admi@gmail.com"); // Corregido

            if (usuario == null)
            {
                var user = new IdentityUser { UserName = "Admi@gmail.com", Email = "Admi@gmail.com" };
                var result = await _userManager.CreateAsync(user, "123456");

                await _userManager.AddToRoleAsync(user, "Administrador");
                creado = result.Succeeded;
                return Json(creado);
            }
            return Json("Listo");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}