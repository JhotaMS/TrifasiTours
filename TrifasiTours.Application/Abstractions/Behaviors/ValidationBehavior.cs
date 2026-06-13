using FluentValidation;
using FluentValidation.Results;
using TrifasiTours.Application.Exceptions;
using MediatR;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993

namespace TrifasiTours.Application.Abstractions.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> _validators
) : IPipelineBehavior<TRequest, TResponse>
<<<<<<< HEAD
    where TRequest : IRequest<TResponse> {

=======
    where TRequest : IRequest<TResponse>
{
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
<<<<<<< HEAD
    ) {

        if (_validators.Any()) {
            ValidationContext<TRequest> context = new( request );
            var validationResult = await Task.WhenAll(
                _validators.Select( v => v.ValidateAsync( context, cancellationToken ) ) );

            List<ValidationFailure> failures = validationResult
                .SelectMany( r => r.Errors )
                .Where( f => f != null )
                .ToList();

            if (failures.Count != 0) {
                throw new ValidationApplicationException( failures );
=======
    )
    {
        if (_validators.Any())
        {
            ValidationContext<TRequest> context = new(request);
            var validationResult = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            List<ValidationFailure> failures = validationResult
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var messages = failures.Select(f => f.ErrorMessage ?? "Validation error");
                throw new ValidationApplicationException(messages);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
            }
        }
        return await next();
    }
}
