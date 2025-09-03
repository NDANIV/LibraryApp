using LibraryApp.Domain.DTOs;

namespace LibraryApp.Domain.Interfaces;

public interface IBookService
{
    // Crear libro
    Task<BookDto> CreateAsync(CreateBookDto dto, CancellationToken ct = default);

    // Obtener todos los libros
    Task<List<BookDto>> GetAllAsync(CancellationToken ct = default);
}
