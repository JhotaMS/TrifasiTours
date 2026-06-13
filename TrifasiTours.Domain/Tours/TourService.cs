using TrifasiTours.Domain.DomainService;
using TrifasiTours.Domain.Ports;

namespace TrifasiTours.Domain.Tours;

[DomainService]
public class TourService(
    IUnitOfWork unitOfWork
) {

    public async Task<Guid> CreateTourAsync(
        Tour tour,
        CancellationToken cancellationToken
    ) {
        ArgumentNullException.ThrowIfNull( nameof( tour ) );

        await unitOfWork.Repository<Tour>()
            .AddAsync( tour, cancellationToken );

        return tour.Id;
    }
}
