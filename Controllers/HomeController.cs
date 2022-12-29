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

    public async Task<IActionResult> Index()
    {
        var usuarios = await _repositorio.ListarTodos();

        return View(usuarios);
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
            return RedirectToAction(nameof(Index));
        }

        return View(usuarioModel);
    }

    public async Task<IActionResult> Editar(int id)
    {
        var usuario = await _repositorio.BuscarUsuario(id);

        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, UsuarioModel usuarioModel)
    {
        if (id != usuarioModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _repositorio.Alterar(usuarioModel);
            return RedirectToAction(nameof(Index));
        }

        return View(usuarioModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
