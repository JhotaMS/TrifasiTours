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

        // Validaciones de unicidad: Email y Documento
        bool emailExists = await unitOfWork.Repository<User>()
            .Exitst( u => u.Email == user.Email, cancellationToken );

        if (emailExists)
            throw new InvalidOperationException("Email already exists");

        bool documentExists = await unitOfWork.Repository<User>()
            .Exitst( u => u.Document == user.Document, cancellationToken );

        if (documentExists)
            throw new InvalidOperationException("Document already exists");

        await unitOfWork.Repository<User>()
            .AddAsync( user, cancellationToken );

        return user.Id;
    }
}
