namespace TrifasiTours.Application.Exceptions;

public class BadRequestApplicationException : ApplicationException {
    public BadRequestApplicationException( string? message ) : base( message ) {

    }
}
