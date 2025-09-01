using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Queries.Users;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    public async Task<IActionResult> QueryUsers(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUsers(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("query/all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    public async Task<IActionResult> QueryAllUsers(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUsers(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("associates/query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    public async Task<IActionResult> QueryUserAssociates(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserAssociates(request), cancellationToken);

        return Ok(result);
    }
}
