namespace LibraryApp.Domain.DTOs;

public record CreateAuthorDto(string FullName, DateTime BirthDate, string City, string Email);
public record AuthorDto(int Id, string FullName, DateTime BirthDate, string City, string Email);
