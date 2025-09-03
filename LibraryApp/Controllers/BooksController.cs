using LibraryApp.Domain.DTOs;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _svc;
    private readonly AppDbContext _db;

    public BooksController(IBookService svc, AppDbContext db)
    {
        _svc = svc;
        _db = db;
    }
    //Obtener autores
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Authors = await _db.Authors
            .Select(a => new { a.Id, a.FullName })
            .ToListAsync();
        return View();
    }
    //Registrar libro
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto dto)
    {
        if (!ModelState.IsValid) return await Create();

        try
        {
            await _svc.CreateAsync(dto);
            TempData["ok"] = "Libro registrado correctamente";
            return RedirectToAction(nameof(Create));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return await Create();
        }
    }
}
