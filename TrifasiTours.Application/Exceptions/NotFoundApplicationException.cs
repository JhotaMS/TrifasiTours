namespace TrifasiTours.Application.Exceptions;

<<<<<<< HEAD
public class NotFoundApplicationException : ApplicationException {
    public NotFoundApplicationException(
        string name,
        object key
    ) : base( $"Entity \"{name}\" ({key}) no fue encontrado" ) {

=======
public class NotFoundApplicationException : Exception
{
    public int StatusCode { get; } = 404;

    public NotFoundApplicationException(string message)
        : base(message)
    {
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    }
}
