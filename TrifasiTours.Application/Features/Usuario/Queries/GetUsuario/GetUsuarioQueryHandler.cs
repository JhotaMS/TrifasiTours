using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Application.Features.Usuario.Queries.GetHello;

public record GetUsuarioQuery(
    string Name
) : IQuery<string>;

internal class GetUsuarioQueryHandler : IQueryHandler<GetUsuarioQuery, string> {
    public async Task<Result<string>> Handle(
        GetUsuarioQuery request,
        CancellationToken cancellationToken
    ) {
        await Task.Delay( 100, cancellationToken ); // Simulate async operation
        return Result<string>.Success( $"Hello {request.Name}!" );
    }
}
