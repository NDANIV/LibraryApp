using LibraryApp.Domain.DTOs;

namespace LibraryApp.Domain.Interfaces;

public interface IAuthorService
{
    Task<AuthorDto> CreateAsync(CreateAuthorDto dto, CancellationToken ct = default);
}
