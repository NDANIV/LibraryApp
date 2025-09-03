using LibraryApp.Domain.DTOs;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryApp.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _db;
    private readonly int _maxBooks;

    public BookService(AppDbContext db, IOptions<AppOptions> opts)
    {
        _db = db;
        _maxBooks = opts.Value.MaxBooks;
    }

    public async Task<BookDto> CreateAsync(CreateBookDto dto, CancellationToken ct = default)
    {
        // Verificar si el autor existe
        var authorExists = await _db.Authors.AnyAsync(a => a.Id == dto.AuthorId, ct);
        if (!authorExists) throw new AuthorNotRegisteredException();

        // Verificar límite de libros
        var totalBooks = await _db.Books.CountAsync(ct);
        if (totalBooks >= _maxBooks) throw new MaxBooksExceededException();

        // Registrar libro
        var e = new Book {
            Title = dto.Title,
            Year = dto.Year,
            Genre = dto.Genre,
            Pages = dto.Pages,
            AuthorId = dto.AuthorId
        };

        _db.Books.Add(e);
        await _db.SaveChangesAsync(ct);

        return new BookDto(e.Id, e.Title, e.Year, e.Genre, e.Pages, e.AuthorId);
    }

    // Obtener todos los libros
    Task<List<BookDto>> GetAllAsync(CancellationToken ct = default);
}

