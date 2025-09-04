using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Commands.Products;
using Saltro.Application.Payloads;
using Saltro.Application.Queries.Products;

namespace Saltro.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSourceResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> QueryProducts(DataSourceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProducts(request), cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> AddProduct(CreateProductRequest payload, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateProduct(payload), cancellationToken);

        return Ok();
    }
}