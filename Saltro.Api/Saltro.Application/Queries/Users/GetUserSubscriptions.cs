using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetUserSubscriptions(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetUserSubscriptionsHandler(IUserSubscriptionRepository repository, ILogger<GetUserSubscriptionsHandler> logger) 
    : IRequestHandler<GetUserSubscriptions, DataSourceResult>
{
    private readonly IUserSubscriptionRepository _repository = repository;
    private readonly ILogger<GetUserSubscriptionsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetUserSubscriptions request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Include(i => i.User)
                .Select(UserMappingProfiles.MapSubscriptions())
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query Users with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}
