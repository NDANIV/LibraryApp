using LibraryApp.Domain.DTOs;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorService _svc;
    public AuthorsController(IAuthorService svc) { _svc = svc; }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _svc.CreateAsync(dto);
        TempData["ok"] = "Autor registrado correctamente";

        return RedirectToAction(nameof(Create));
    }
}
