using LibraryApp.Domain.DTOs;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure;

namespace LibraryApp.Services;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _db;
    public AuthorService(AppDbContext db) { _db = db; }

    public async Task<AuthorDto> CreateAsync(CreateAuthorDto dto, CancellationToken ct = default)
    {
        var e = new Author {
            FullName = dto.FullName,
            BirthDate = dto.BirthDate,
            City = dto.City,
            Email = dto.Email
        };

        _db.Authors.Add(e);
        await _db.SaveChangesAsync(ct);

        return new AuthorDto(e.Id, e.FullName, e.BirthDate, e.City, e.Email);
    }
}
