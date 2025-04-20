using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CommunyTalk.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CommunyTalk.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    public IActionResult SearchCommunities()
    {
       ViewBag.Comunidades = BD.ObtenerComunidades(); 
        return View();
    }

    public IActionResult CommunyChat(int IdComunidad)
    {
        BD.IdComunidadActual = IdComunidad;
        ViewBag.Mensajes = BD.ObtenerMensajesComunidad(IdComunidad);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View();
    }

    public IActionResult EnviarMensajeComunidad(string Contenido, int IdUsuario)
    {
        BD.EnviarMensajeComunidad(Contenido, IdUsuario);
        ViewBag.Mensajes = BD.ObtenerMensajesComunidad(BD.IdComunidadActual);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View("CommunyChat");
    }

    public IActionResult SearchGroups()
    {
        ViewBag.Grupos = BD.ObtenerGrupos();
        ViewBag.IntegrantesGrupo = BD.ObtenerIntegrantesGrupos();
        return View();
    }

    public IActionResult SearchInterests(){
        ViewBag.Intereses = BD.ObtenerIntereses();
        return View();
    }

    public IActionResult GroupChat(int IdGrupo)
    {
        BD.IdGrupoActual = IdGrupo;
        ViewBag.Mensajes = BD.ObtenerMensajesGrupo(IdGrupo);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View();
    }

    public IActionResult EnviarMensajeGrupo(string Contenido, int IdUsuario)
    {
        BD.EnviarMensajeGrupo(Contenido, IdUsuario);
        ViewBag.Mensajes = BD.ObtenerMensajesGrupo(BD.IdGrupoActual);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View("GroupChat");
    }

    public IActionResult PrivateChat(int IdUsuario)
    {
        BD.IdChatActual = IdUsuario;
        ViewBag.Mensajes = BD.ObtenerMensajesPrivado(IdUsuario);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View();
    }
    
    public IActionResult EnviarMensajePrivado(string Contenido, int IdUsuario)
    {
        BD.EnviarMensajePrivado(Contenido, IdUsuario);
        ViewBag.Mensajes = BD.ObtenerMensajesPrivado(BD.IdChatActual);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View("PrivateChat");
    } 

   public IActionResult ObtenerMensajesPrivado()
    {
    var mensajes = BD.ObtenerMensajesPrivado(BD.IdChatActual);
    ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
    return PartialView("_MensajesPrivado", mensajes);
    }

    public IActionResult SearchFriends()
    {
        ViewBag.StatusBusqueda = BD.StatusBusqueda;

        if(BD.StatusBusqueda)
        {
            ViewBag.Usuarios = BD.ObtenerUsuarios();
        }
        else
        {
            ViewBag.Usuarios = BD.ObtenerAmigos();
        }

        return View();
    }

    public IActionResult CambiarBusquedaAmigos()
    {
        BD.StatusBusqueda = !BD.StatusBusqueda;
        ViewBag.StatusBusqueda = BD.StatusBusqueda;
        
        if(BD.StatusBusqueda)
        {
            ViewBag.Usuarios = BD.ObtenerUsuarios();
        }
        else
        {
            ViewBag.Usuarios = BD.ObtenerAmigos();
        }

        return View("SearchFriends");
    }

    public IActionResult Login(){
        
        if (HttpContext.Session.GetString("user") != null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    public IActionResult VerificarContraseña(string Usuario, string Contraseña)
    {
        if (string.IsNullOrEmpty(Contraseña)  || string.IsNullOrEmpty(Usuario) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Login");
        }
        else
        {
            Usuarios comparar = BD.LoginIngresado(Usuario, Contraseña);

            if (comparar != null)
            {
                if (Contraseña == comparar.Contraseña)
                {
                    BD.IdUsuarioSesion = comparar.IdUsuario;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o contraseña ingresada son incorrectos";
            }

            return View("Login");
        }
    }

    public IActionResult Registrar(bool error){
        ViewBag.Error = error;

        return View("Registrar");
    }

    public IActionResult GuardarUsuario(string Usuario, string Contraseña, string Contraseña2, string Email)
    {
        if (Contraseña != Contraseña2 || string.IsNullOrEmpty(Usuario) ||  string.IsNullOrEmpty(Contraseña) || string.IsNullOrEmpty(Email))
        {
            return RedirectToAction("Registrar" , "Home", new {error = true});
        }
        else
        {
            BD.AñadirUsuario(Usuario, Contraseña, Email);
            return RedirectToAction("AvisoRegistro");
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("user");
        BD.IdUsuarioSesion = 0;
        return RedirectToAction("Index");
    }

    public IActionResult Settings()
    {
        return View("Settings");
    }

    public IActionResult Usuario()
    {

        return View("PerfilUsuario");
    }

    public IActionResult EditarUsuario()
    {
        return View("EditarUsuario");
    }

    public IActionResult EditarPerfil(string FotodePerfil, string NameTag, string Nombre, string Apellido, string Pronombres, string Descripcion)
    {
        if(FotodePerfil != null) BD.CambiarFoto(FotodePerfil);
        if(NameTag != null) BD.CambiarNameTag(NameTag);
        if(Nombre != null) BD.CambiarNombre(Nombre);
        if(Apellido != null) BD.CambiarApellido(Apellido);
        if(Pronombres != null) BD.CambiarPronombres(Pronombres);
        if(Descripcion != null) BD.CambiarDescripcion(Descripcion);
        return View("EditarUsuario");
    }

    public IActionResult CrearGrupo()
    {
        ViewBag.Usuarios = BD.ObtenerUsuarios();
        return View("CrearGrupo");
    }
[HttpPost]
public IActionResult InfoGrupo(string FotodePerfil, string Nombre, string Descripcion, int Privado, int IdAdmin)
{
    bool esPrivado = Privado == 1;
    if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Descripcion))
    {
        var grupo = new Grupos
        {
            FotodePerfil = FotodePerfil,
            Nombre = Nombre,
            Descripcion = Descripcion,
            Privado = esPrivado,
            IdAdmin = IdAdmin,
        };

        BD.InsertGroup(grupo);

        return View("Index");
    }

    return View("Index");
}

public IActionResult AvisoRegistro()
{
    return View("AvisoRegistro");
}
}