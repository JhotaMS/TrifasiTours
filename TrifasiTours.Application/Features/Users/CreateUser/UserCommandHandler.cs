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
        try {
            var user = User.Create(
                request.FirstName,
                request.SecondName,
                request.Age,
                request.Email,
                request.Password,
                request.Document,
                request.Role,
                request.Enabled
            );

            Guid id = await userService
                .CreateUserAsync(
                    user,
                    cancellationToken
                );

            return Result.Success( new UserCommandResponse( id ) );
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains( "Email" )) {
            return Result.Failure<UserCommandResponse>( new TrifasiTours.Domain.Abstractions.Error( "Error.DuplicateEmail", "El email ya existe" ) );
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains( "Document" )) {
            return Result.Failure<UserCommandResponse>( new TrifasiTours.Domain.Abstractions.Error( "Error.DuplicateDocument", "El documento ya existe" ) );
        }
        catch (ArgumentException ex) {
            return Result.Failure<UserCommandResponse>( new TrifasiTours.Domain.Abstractions.Error( "Error.Validation", "" + ex.Message ) );
        }
    }
}
