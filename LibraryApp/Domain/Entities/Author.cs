using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Domain.Entities;

public class Author
{
    public int Id { get; set; }

    [Required] public string FullName { get; set; } = default!;

    [Required] public DateTime BirthDate { get; set; }

    [Required] public string City { get; set; } = default!;

    [Required, EmailAddress] public string Email { get; set; } = default!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}