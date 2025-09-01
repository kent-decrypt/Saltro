using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Products;

public record GetAllProducts(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetAllProductsHandler(IProductRepository repository) : IRequestHandler<GetAllProducts, DataSourceResult>
{
    private readonly IProductRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Select(ProductMappingProfiles.MapProducts())
            .OrderBy(i => i.Id)
            .ToDataSourceResult(request.Request);

        return Task.FromResult(query);
    }
}