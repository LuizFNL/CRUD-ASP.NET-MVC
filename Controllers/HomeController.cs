using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormMVC.Models;
using FormMVC.Repositories;

namespace FormMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUsuarioRepositorio _repositorio;

    public HomeController(ILogger<HomeController> logger, IUsuarioRepositorio repositorio)
    {
        _logger = logger;
        _repositorio = repositorio;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuarioModel)
    {
        if (ModelState.IsValid)
        {
            _repositorio.Adicionar(usuarioModel);
        }

        return View(usuarioModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
