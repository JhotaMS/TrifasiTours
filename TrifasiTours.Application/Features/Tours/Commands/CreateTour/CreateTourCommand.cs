using System;
using TrifasiTours.Application.Messaging;

namespace TrifasiTours.Application.Features.Tours.Commands.CreateTour;

public record CreateTourCommand(
    string Name,
    string TipoTour,
    string Municipio,
    string Dificultad,
    decimal ValorTour,
    Guid GuiaAsignadoId,
    string Requisitos
) : ICommand<CreateTourResponse>;
