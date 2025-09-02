namespace LibraryApp.Domain.Exceptions;

public class MaxBooksExceededException : Exception
{
    public MaxBooksExceededException()
        : base("No es posible registrar el libro, se alcanzó el máximo permitido.") {}
}
