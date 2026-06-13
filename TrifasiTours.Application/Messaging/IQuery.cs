using TrifasiTours.Domain.Abstractions;
using MediatR;

namespace TrifasiTours.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}