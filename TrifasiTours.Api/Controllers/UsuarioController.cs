using Microsoft.AspNetCore.Mvc;
using TrifasiTours.Application.Features.Usuario.Queries.GetHello;
using TrifasiTours.Application.Messaging;

namespace TrifasiTours.Api.Controllers;

[ApiController]
[Route( "api/v1/[controller]" )]
public class UsuarioController : ControllerBase {

    private readonly ILogger<UsuarioController> _logger;
    private readonly IDispatch _dispatch;

    public UsuarioController
        (
        ILogger<UsuarioController> logger,
        IDispatch dispatch
    ) {
        _logger = logger;
        _dispatch = dispatch;
    }
    [HttpPost( "name" )]
    public async Task<ActionResult> Name(
        [FromBody] GetUsuarioQuery getUsuarioQuery,
        CancellationToken CancellationToken
        ) {
        return Ok( await _dispatch.Send( getUsuarioQuery, CancellationToken ) );

    }
}

// api/v1/Usuario 