using LibraryApp.Domain.DTOs;

namespace LibraryApp.Domain.Interfaces;

public interface IAuthorService
{
    // Crear autor
    Task<AuthorDto> CreateAsync(CreateAuthorDto dto, CancellationToken ct = default);

    // Obtener todos los autores
    Task<List<AuthorDto>> GetAllAsync(CancellationToken ct = default);
}
