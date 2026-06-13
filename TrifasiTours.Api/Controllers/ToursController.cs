using TrifasiTours.Application.Features.Tours.Commands.CreateTour;
using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace TrifasiTours.Api.Controllers;

[Route("v1/[controller]")]
public class ToursController(
    ILogger<ToursController> logger,
    IDispatch dispatch
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result>> CreateTourAsync(
        [FromBody] CreateTourCommand command,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("Se solicita creación de tour: {name}", command?.Name);
        return await dispatch.Send(command, cancellationToken);
    }
}
