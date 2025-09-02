using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Products;

public record GetAllProducts(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetAllProductsHandler(IProductRepository repository, ILogger<GetAllProductsHandler> logger) : IRequestHandler<GetAllProducts, DataSourceResult>
{
    private readonly IProductRepository _repository = repository;
    private readonly ILogger<GetAllProductsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Select(ProductMappingProfiles.MapProducts())
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query all Products with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}