using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Products;

public record GetProducts(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetProductsHandler(IProductRepository repository, ILogger<GetProductsHandler> logger) : IRequestHandler<GetProducts, DataSourceResult>
{
    private readonly IProductRepository _repository = repository;
    private readonly ILogger<GetProductsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Where(i => i.DeletedDate == null && i.IsActive)
                .Select(ProductMappingProfiles.MapProducts())
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query Products with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}