using FluentValidation.Results;

namespace TrifasiTours.Application.Exceptions;

<<<<<<< HEAD
public class ValidationApplicationException : ApplicationException {
    public IDictionary<string, string[]> Errors { get; set; }
    public ValidationApplicationException() : base( "Se ha presentado uno o más errores de validación" ) {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationApplicationException( IEnumerable<ValidationFailure> failures ) : this() {
        Errors = failures
            .GroupBy( e => e.PropertyName, e => e.ErrorMessage )
            .ToDictionary(
                failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray() );
=======
public class ValidationApplicationException : Exception {
    public IEnumerable<string> Errors { get; }

    public ValidationApplicationException( IEnumerable<string> errors )
        : base( "Validation failed." ) {
        Errors = errors?.ToArray() ?? Array.Empty<string>();
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    }
}
