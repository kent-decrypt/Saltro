using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Queries.Carts;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController(ILogger<CartsController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<CartsController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    public async Task<IActionResult> QueryCarts(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCarts(request), cancellationToken);

        return Ok(result);
    }
}