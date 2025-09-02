using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Carts;

public sealed record GetCartItems(int CartId, DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetCartItemsHandler(ICartItemRepository repository, ILogger<GetCartItemsHandler> logger) : IRequestHandler<GetCartItems, DataSourceResult>
{
    private readonly ICartItemRepository _repository = repository;
    private readonly ILogger<GetCartItemsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetCartItems request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Include(i => i.Item)
                .Select(CartMappingProfiles.MapCartItems(request.CartId))
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query Cart Items with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}