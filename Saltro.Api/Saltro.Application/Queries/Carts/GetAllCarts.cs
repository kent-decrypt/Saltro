using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Carts;

public record GetAllCarts(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetAllCartsHandler(ICartRepository repository, ILogger<GetAllCartsHandler> logger) : IRequestHandler<GetAllCarts, DataSourceResult>
{
    private readonly ICartRepository _repository = repository;
    private readonly ILogger<GetAllCartsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetAllCarts request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Where(i => i.DeletedDate == null)
                .Select(CartMappingProfiles.MapCarts())
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query All Carts with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}