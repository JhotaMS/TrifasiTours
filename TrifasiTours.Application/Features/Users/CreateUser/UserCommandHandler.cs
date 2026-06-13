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
<<<<<<< HEAD
                    request.Nombre
                    , request.Edad
                    , request.Documento
                    , request.Correo
                    , request.FechaNacimiento
                    , request.Rol
=======
                    request.FirstName
                    , request.SecondName
                    , request.SurName
                    , request.SecondSurName
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
                )
                , cancellationToken
            );

        return new UserCommandResponse( id );
    }
}
