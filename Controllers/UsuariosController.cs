using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesisPadel.Data;
using TesisPadel.Models;
namespace TesisPadel.Controllers;
public class UsuariosController : Controller{
    private readonly ILogger<UsuariosController>_logger;
      private TesisPadelDbContext _contexto;

    public string? Nombre { get; private set; }

    public UsuariosController(ILogger<UsuariosController> logger, TesisPadelDbContext contexto)
    {
        _logger = logger;
        _contexto= contexto;
    }
    public IActionResult Index()
    {
        return View();
    }
    public JsonResult BuscarUsuarios (int UsuarioId =0)
    {
        var Usuarios = _contexto.Usuarios.ToList();
        if (UsuarioId>0){
            Usuarios = Usuarios.Where(u=>u.UsuarioId ==UsuarioId).OrderBy(u=>u.Nombre).ToList();
            }
            return Json(Usuarios);
     }
     public JsonResult GuardarUsuario (int UsuarioId =0){
         bool resultado = false;
    if (!string.IsNullOrEmpty(Nombre)){

               
                         //SI ES 0 QUIERE DECIR QUE ESTA CREANDO EL USUARIO
                     if(UsuarioId == 0){
                         //BUSCAMOS EN LA TABLA SI EXISTE UNA CON LA MISMA DESCRIPCION
                         var usuarioOriginal = _contexto.Usuarios.Where(u => u.Nombre == Nombre).FirstOrDefault();
                 if(usuarioOriginal == null){
                       //DECLAMOS EL OBJETO DANDO EL VALOR
                         var usuarioGuardar = new Usuario{
                             Nombre = Nombre
                         };
                         _contexto.Add(usuarioGuardar);
                         _contexto.SaveChanges();
                         resultado = true;

                 }

                     
                     }
                     else{
                         //BUSCAMOS EN LA TABLA SI EXISTE UNA CON LA MISMA DESCRIPCION Y DISTINTO ID DE REGISTRO AL QUE ESTAMOS EDITANDO
                         var usuarioOriginal = _contexto.Usuarios.Where(u => u.Nombre == Nombre && u.UsuarioId != UsuarioId).FirstOrDefault();
                         if(usuarioOriginal == null){
                             //crear variable que guarde el objeto segun el id deseado
                             var usuarioEditar = _contexto.Usuarios.Find(UsuarioId);
                             if(usuarioEditar != null){
                                 usuarioEditar.Nombre = Nombre;
                                 _contexto.SaveChanges();
                                  resultado = true;
                             }
                         }
                       
           
                        }                          
         }

         return Json(resultado);
          
    }
}