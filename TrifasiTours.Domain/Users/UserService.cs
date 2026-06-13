using TrifasiTours.Domain.DomainService;
using TrifasiTours.Domain.Ports;

namespace TrifasiTours.Domain.Users;

[DomainService]
public class UserService(
    IUnitOfWork unitOfWork
) {

    public async Task<Guid> CreateUserAsync(
        User user,
        CancellationToken cancellationToken
    ) {
        ArgumentNullException.ThrowIfNull( nameof( user ) );

        await unitOfWork.Repository<User>()
            .AddAsync( user, cancellationToken );

        return user.Id;
    }
}
