using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Queries.Users;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryUsers(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUsers(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("query/all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryAllUsers(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUsers(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("associates/query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryUserAssociates(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserAssociates(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("subscriptions/query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryUserSubscriptions(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserSubscriptions(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost("usergroups/query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryUserGroups(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserGroups(request), cancellationToken);

        return Ok(result);
    }
}
