using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public sealed record GetUserGroups(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetUserGroupsHandler(IUserGroupRepository repository, ILogger<GetUserGroupsHandler> logger) 
    : IRequestHandler<GetUserGroups, DataSourceResult>
{
    private readonly IUserGroupRepository _repository = repository;
    private readonly ILogger<GetUserGroupsHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetUserGroups request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Select(UserMappingProfiles.MapUserGroups())
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query User Groups with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}
