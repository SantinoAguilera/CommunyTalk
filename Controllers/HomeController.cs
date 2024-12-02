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

    public IActionResult SearchFriends()
    {
        ViewBag.Usuarios = BD.ObtenerUsuarios();
        ViewBag.StatusBusqueda = BD.StatusBusqueda;
        return View();
    }

    public IActionResult CambiarBusquedaAmigos()
    {
        ViewBag.Usuarios = BD.ObtenerUsuarios();
        BD.StatusBusqueda = !BD.StatusBusqueda;
        ViewBag.StatusBusqueda = BD.StatusBusqueda;
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

    public IActionResult Registrar(string error){
        if (error == null)
        {
            ViewBag.Error = false;
        }
        ViewBag.Error = true;
        return View("Registrar");
    }

    public IActionResult GuardarUsuario(Usuarios nuevoUser, string Contraseña2)
    {
        if (nuevoUser.Contraseña != Contraseña2 || string.IsNullOrEmpty(nuevoUser.Nametag) ||  string.IsNullOrEmpty(nuevoUser.Contraseña) || string.IsNullOrEmpty(nuevoUser.Email))
        {
            return RedirectToAction("Registro" , "Home", new {error = true});
        }
        else
        {
            BD.InsertUser(nuevoUser);
            return RedirectToAction("Login");
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("user");
        return RedirectToAction("Login");
    }

    public IActionResult Settings()
    {
        return View("Settings");
    }

    public IActionResult Usuario (){

        return View("PerfilUsuario");
    }

    public IActionResult EditarUsuario (){
        return View("EditarUsuario");
    }

    public IActionResult CrearGrupo (){
        return View("CrearGrupo");
    }
/*
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment){
        Environment = environment;
    }

    [HttpPost]
    public IActionResult FotoPerfil(IFormFile fotoDePerfil){
        if(fotoDePerfil.Length>0){
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + fotoDePerfil.FileName;
        using (var stream = System.IO.File.Create(wwwRootLocal)){
            fotoDePerfil.CopyToAsync(stream);
        }
        }
    } 
*/    
}