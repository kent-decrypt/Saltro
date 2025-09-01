using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Carts;

public record GetCarts(DataSourceRequest request) : IRequest<DataSourceResult>;

internal sealed class GetCartsHandler(ICartRepository repository) : IRequestHandler<GetCarts, DataSourceResult>
{
    private readonly ICartRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetCarts request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Where(i => i.DeletedDate == null)
            .Select(CartMappingProfiles.MapCarts())
            .OrderBy(i => i.Id)
            .ToDataSourceResult(request.request);

        return Task.FromResult(query);
    }
}