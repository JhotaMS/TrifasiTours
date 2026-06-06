namespace TrifasiTours.Application.Exceptions;

public class NotFoundApplicationException : Exception
{
    public int StatusCode { get; } = 404;

    public NotFoundApplicationException(string message)
        : base(message)
    {
    }
}
