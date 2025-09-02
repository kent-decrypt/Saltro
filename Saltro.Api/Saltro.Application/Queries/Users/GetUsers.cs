using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetUsers(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetUsersHandler(IUserRepository repository, ILogger<GetUsersHandler> logger) : IRequestHandler<GetUsers, DataSourceResult>
{
    private readonly IUserRepository _repository = repository;
    private readonly ILogger<GetUsersHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Where(i => i.DeletedDate == null)
                .Select(UserMappingProfiles.MapUsers())
                .OrderBy(i => i.Id)
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
