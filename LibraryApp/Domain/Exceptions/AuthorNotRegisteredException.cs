namespace LibraryApp.Domain.Exceptions;

public class AuthorNotRegisteredException : Exception
{
    public AuthorNotRegisteredException()
        : base("El autor no está registrado") {}
}
