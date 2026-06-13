using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Users;

namespace TrifasiTours.Application.Features.Users.CreateUser;
internal sealed class UserCommandHandler( 
    UserService userService 
) : ICommandHandler<UserCommand, UserCommandResponse> {
    
    public async Task<Result<UserCommandResponse>> Handle( UserCommand request
        , CancellationToken cancellationToken 
    ) {
        Guid id = await userService
            .CreateUserAsync(
                User.Create(
                    request.Nombre
                    , request.Edad
                    , request.Documento
                    , request.Correo
                    , request.FechaNacimiento
                    , request.Rol
                )
                , cancellationToken
            );

        return new UserCommandResponse( id );
    }
}
