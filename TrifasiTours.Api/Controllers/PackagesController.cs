using TrifasiTours.Application.Features.Packages.CreatePackage;
using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace TrifasiTours.Api.Controllers;

[Route("v1/[controller]")]
public class PackagesController(
    ILogger<PackagesController> logger,
    IDispatch dispatch
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<CreatePackageResponse>>> CreatePackageAsync(
        [FromBody] CreatePackageCommand request,
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString("dd/MM/yyyy", provider: new CultureInfo("es-CO")),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString("hh:mm tt"),
                "PackagesController",
                nameof(PackagesController)
        );

        return await dispatch.Send(request, cancellationToken);
    }
}
