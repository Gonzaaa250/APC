// using TesisPadel.Data;
// using TesisPadel.Models;

// namespace TesisPadel.Controller;
// public class LoginController : Controller
// {
//     private readonly ILogger<LoginController> _logger;
//     private readonly TesisPadelDbContext _context;
//     public LoginController(ILogger<LoginController> logger, TesisPadelDbContext _context)
//     {
//         _logger= _logger;
//         _context= _context;
//     }
//     public IActionResult Index()
//     {
//         return View();
//     }
//     public jsonresult RegistrarUsuario(){
//         var usuario = new Usuario();
//         if (ModelState.IsValid){
//             try
//             {
//                 using (_context as DbContextBase)
//                 {
//                     usuario=_context.Usuarios
//                     .Where((x)=> x.Nombre==usuario.Nombre &&
//                     x.Apellido == usuario.Apellido).FirstOrDefault();
//                     if (!usuario is null )
//                     ModelState.AddModelError("error", "El nombre de usuario ya existe");
//                     else
//                     {
//                         //_context.Usuarios.Add(_user);
//                         _context.SaveChangesAsync().Wait();
//                         return Json(new { success="true" });
//                         }
//                         }
//                         catch (Exception ex)
//                         {
//                             throw ex;}
//                             }else
//                             return Json(new {success ="false"});}
//                             [HttpPost]
//                             public async Task <jsonresult > IniciarSesion([FromBody] Usuario user ){
//                                 var result = await ValidarCredenciales(user );
//                                 if(!string.IsNullOrEmpty(result)){
//                                     HttpContext.Session.SetString("_idUser", user._id.ToString());
//                                     HttpContext.Session.SetInt32("_tipoId", 10);//TODO: cambiar por tipo de usuario
//                                     HttpContext.Response.Cookies.Append(".AspNetCore.Identity.Application","",)
//                                     HttpContext.Session.SetInt32("_tipoId", 1);//TODO: cambiar tipo a un enumerado
//                                     HttpContext.Session.SetInt32("_tipoUsuarioId", Convert.ToInt16(user.TipoUsuario));
//                                     HttpContext.Session.SetInt32("_tipoId", Convert.ToInt16(user.Tipo));
//                                     HttpContext.Session.SetString("_nombreCompleto", $"{user.Nombre} {user.Apellido}");
//                                     HttpContext.Response.Cookies.Append(".AspNetCore.Identity.Application","");
//                                     return  Json(new { success = true});
//                                     }
//                                     else{
//                                         return   Json(new { success = false , error = $"Datos incorrectos"});
//                                         }}
//                                         private async Task< string>ValidarCredenciales(Usuario user){
//                                             var resultado="";
//                                             switch ((int)(user?.Tipo))
//     }
// }
// }