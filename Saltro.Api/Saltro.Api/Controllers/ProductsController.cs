using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Queries.Products;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(ILogger<ProductsController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<ProductsController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    public async Task<IActionResult> QueryProducts(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProducts(request), cancellationToken);

        return Ok(result);
    }
}