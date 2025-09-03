namespace LibraryApp.Domain.DTOs;

public record CreateBookDto(string Title, int Year, string Genre, int Pages, int AuthorId);
public record BookDto(int Id, string Title, int Year, string Genre, int Pages, int AuthorId);
