using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CommunyTalk.Models;

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

    public IActionResult SearchGroups()
    {
        ViewBag.Grupos = BD.ObtenerGrupos();
        return View();
    }

    public IActionResult GroupChat(int IdGrupo)
    {
        ViewBag.Mensajes = BD.ObtenerMensajesGrupo(IdGrupo);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View();
    }

    public IActionResult PrivateChat(int IdUsuario)
    {
        ViewBag.Mensajes = BD.ObtenerMensajesPrivado(IdUsuario);
        ViewBag.IdUsuarioSesion = BD.IdUsuarioSesion;
        return View();
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

    [HttpPost]
    public IActionResult VerificarLogin(string email, string password)
    {
        if (email == "admin@gmail.com" && password == "admin")
        {
            HttpContext.Session.SetString("user", new Usuarios(email, password).ToString());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error = "Email o contraseña incorrectos.";
            return View("Login");
        }
    }

    public IActionResult Registrar(){
        
        return View("Registrar");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("user");
        return RedirectToAction("Login");
    }
}