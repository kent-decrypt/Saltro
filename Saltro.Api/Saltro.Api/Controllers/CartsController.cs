using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Queries.Carts;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController(ILogger<CartsController> logger, IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryCarts(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCarts(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("query/all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryAllCarts(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCarts(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("items/query/{cartId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryCarts(int cartId, DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCartItems(cartId, request), cancellationToken);

        return Ok(result);
    }
}