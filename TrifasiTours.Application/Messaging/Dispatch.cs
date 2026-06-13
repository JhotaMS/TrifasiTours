using MediatR;
using System.Runtime.CompilerServices;
<<<<<<< HEAD

namespace TrifasiTours.Application.Messaging;
public class Dispatch( IMediator mediator ) : IDispatch {
    private readonly IMediator _mediator = mediator;

    public async IAsyncEnumerable<TResponse> CreateStream<TResponse>( 
        IStreamRequest<TResponse> request
        , [EnumeratorCancellation] CancellationToken cancellationToken = default 
    ) {
        IAsyncEnumerable<TResponse> responseStream = _mediator.CreateStream( request
            , cancellationToken 
        );
        
        await foreach (var response in responseStream.WithCancellation( cancellationToken )) {
            yield return response;
        }
    }
    public async IAsyncEnumerable<object?> CreateStream( 
        object request
        , [EnumeratorCancellation] CancellationToken cancellationToken = default
    ) {
        var responseStream = _mediator.CreateStream( request
            , cancellationToken 
        );
        
        await foreach (var response in responseStream.WithCancellation( cancellationToken )) {
            yield return response;
        }
    }
    public Task Publish(
        object notification
        , CancellationToken cancellationToken = default
    ) => _mediator.Publish( notification, cancellationToken );
=======
using System.Threading;

namespace TrifasiTours.Application.Messaging;
public class Dispatch : IDispatch
{
    private readonly IMediator _mediator;

    public Dispatch(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(
        IStreamRequest<TResponse> request
        , [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        IAsyncEnumerable<TResponse> responseStream = _mediator.CreateStream(request, cancellationToken);

        await foreach (var response in responseStream.WithCancellation(cancellationToken))
        {
            yield return response;
        }
    }

    public async IAsyncEnumerable<object?> CreateStream(
        object request
        , [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var responseStream = _mediator.CreateStream(request, cancellationToken);

        await foreach (var response in responseStream.WithCancellation(cancellationToken))
        {
            yield return response;
        }
    }

    public Task Publish(
        object notification
        , CancellationToken cancellationToken = default
    ) => _mediator.Publish(notification, cancellationToken);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993

    public Task Publish<TNotification>(
        TNotification notification
        , CancellationToken cancellationToken = default
<<<<<<< HEAD
    ) where TNotification : INotification 
        => _mediator.Publish( notification, cancellationToken );
=======
    ) where TNotification : INotification
        => _mediator.Publish(notification, cancellationToken);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993

    public Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request
        , CancellationToken cancellationToken = default
<<<<<<< HEAD
    ) => _mediator.Send( request, cancellationToken );
=======
    ) => _mediator.Send(request, cancellationToken);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993

    public Task Send<TRequest>(
        TRequest request
        , CancellationToken cancellationToken = default
<<<<<<< HEAD
    ) where TRequest : IRequest 
        => _mediator.Send( request, cancellationToken );
=======
    ) where TRequest : IRequest
        => _mediator.Send(request, cancellationToken);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993

    public Task<object?> Send(
        object request
        , CancellationToken cancellationToken = default
<<<<<<< HEAD
    ) => _mediator.Send( request, cancellationToken );
=======
    ) => _mediator.Send(request, cancellationToken);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
}
