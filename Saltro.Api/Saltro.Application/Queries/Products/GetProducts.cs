using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Products;

public record GetProducts(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetProductsHandler(IProductRepository repository) : IRequestHandler<GetProducts, DataSourceResult>
{
    private readonly IProductRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Where(i => i.DeletedDate == null && i.IsActive)
            .Select(ProductMappingProfiles.MapProducts())
            .OrderBy(i => i.Id)
            .ToDataSourceResult(request.Request);

        return Task.FromResult(query);
    }
}