using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Tours;

namespace TrifasiTours.Application.Features.Tours.CreateTour;
internal sealed class TourCommandHandler(
    TourService tourService
) : ICommandHandler<TourCommand, TourCommandResponse> {

    public async Task<Result<TourCommandResponse>> Handle( TourCommand request
        , CancellationToken cancellationToken
    ) {
        Guid id = await tourService
            .CreateTourAsync(
                Tour.Create(
                    request.NombreTour
                    , request.TipoTour
                    , request.Municipio
                    , request.Codigo
                    , request.Dificultad
                    , request.Requisitos
                    , request.ValorTour
                    , request.GuiaTuristicoId
                )
                , cancellationToken
            );

        return new TourCommandResponse( id );
    }
}
