using LibraryApp.Domain.DTOs;

namespace LibraryApp.Domain.Interfaces;

public interface IBookService
{
    Task<BookDto> CreateAsync(CreateBookDto dto, CancellationToken ct = default);
}
