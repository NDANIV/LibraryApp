using LibraryApp.Domain.DTOs;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorService _svc;
    
    public AuthorsController(IAuthorService svc) { _svc = svc; }
    // GET: Authors/Create
    [HttpGet]
    public IActionResult Create() => View();
    // POST: Authors/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _svc.CreateAsync(dto);
        TempData["ok"] = "Autor registrado correctamente";

        return RedirectToAction(nameof(Create));
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _svc.GetAllAsync();
        return View(authors);
    }


}
