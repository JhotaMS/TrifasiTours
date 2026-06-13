using TrifasiTours.Application.Messaging;
using System.ComponentModel.DataAnnotations;

namespace TrifasiTours.Application.Features.Tours.CreateTour;
public record TourCommand(
    [Required] string NombreTour
    , [Required] string TipoTour
    , [Required] string Municipio
    , [Required] string Codigo
    , [Required] string Dificultad
    , [Required] string Requisitos
    , [Required] decimal ValorTour
    , [Required] Guid GuiaTuristicoId
    ) : ICommand<TourCommandResponse>;
