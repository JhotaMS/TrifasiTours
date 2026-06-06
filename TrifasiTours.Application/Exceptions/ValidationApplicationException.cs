using FluentValidation.Results;

namespace TrifasiTours.Application.Exceptions;

public class ValidationApplicationException : Exception {
    public IEnumerable<string> Errors { get; }

    public ValidationApplicationException( IEnumerable<string> errors )
        : base( "Validation failed." ) {
        Errors = errors?.ToArray() ?? Array.Empty<string>();
    }
}
