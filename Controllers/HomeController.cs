using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers;

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
        _userManager = _userManager;
        _rolManager = _rolManager;
    }

    public async Task<IActionResult> Index()
    {
        // await InicializarPermisosUsuario();
        return View();
    }
    // public async Task<JsonResult> InicializarPermisosUsuario()
    // {
    //     //CREAR ROLES SI NO EXISTEN
    //     var AdministradorExiste = _contextUsuario.Roles.Where(r => r.Name == "Administrador").SingleOrDefault();
    //     if (AdministradorExiste == null)
    //     {
    //         var roleResult = await _rolManager.CreateAsync(new IdentityRole("Administrador"));
    //     }
    //     var UsuarioExiste = _contextUsuario.Roles.Where(r => r.Name == "Usuario").SingleOrDefault();
    //     if (UsuarioExiste == null)
    //     {
    //         var roleResult = await _rolManager.CreateAsync(new IdentityRole("Usuario"));
    //     }


    //     //CREAR USUARIO PRINCIPAL
    //     bool creado = false;
    //     //BUSCAR POR MEDIO DE CORREO ELECTRONICO SI EXISTE EL USUARIO
    //     var usuario = _contextUsuario.Users.Where(u => u.Email == "usuario@sistema.com").SingleOrDefault();
    //     if (usuario == null)
    //     {
    //         var user = new IdentityUser { UserName = "usuario@sistema.com", Email = "usuario@sistema.com" };
    //         var result = await _userManager.CreateAsync(user, "password");

    //         await _userManager.AddToRoleAsync(user, "NombreRolCrear");
    //         creado = result.Succeeded;
    //     }

    //     //CODIGO PARA BUSCAR EL USUARIO EN CASO DE NECESITARLO
    //     var superusuario = _contextUsuario.Users.Where(r => r.Email == "usuario@sistema.com").SingleOrDefault();
    //     if (superusuario != null)
    //     {

    //         //var personaSuperusuario = _contexto.Personas.Where(r => r.UsuarioID == superusuario.Id).Count();

    //         var usuarioID = superusuario.Id;

    //     }

    //     return Json(creado);
    // }
    
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
