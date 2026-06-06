using FluentValidation;
using FluentValidation.Results;
using TrifasiTours.Application.Exceptions;
using MediatR;
using System.Linq;

namespace TrifasiTours.Application.Abstractions.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> _validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
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
            }
        }
        return await next();
    }
}
