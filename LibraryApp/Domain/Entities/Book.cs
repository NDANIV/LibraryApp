using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    [Required] public string Title { get; set; } = default!;

    [Range(1, 2100)] public int Year { get; set; }

    [Required] public string Genre { get; set; } = default!;

    [Range(1, int.MaxValue)] public int Pages { get; set; }

    [Required] public int AuthorId { get; set; }
    public Author? Author { get; set; }
}
