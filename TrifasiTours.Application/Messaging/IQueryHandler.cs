using TrifasiTours.Domain.Abstractions;
using MediatR;

namespace TrifasiTours.Application.Messaging;

public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
