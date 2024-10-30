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
        return View();
    }

    public IActionResult SearchGroups()
    {
        ViewBag.Grupos = BD.ObtenerGrupos();
        return View();
    }

    public IActionResult PrivateChat(){
        return View("PrivateChat");
    }
}