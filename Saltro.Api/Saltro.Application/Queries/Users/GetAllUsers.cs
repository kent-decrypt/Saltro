using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetAllUsers(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetAllUsersHandler(IUserRepository repository, ILogger<GetAllUsersHandler> logger) : IRequestHandler<GetAllUsers, DataSourceResult>
{
    private readonly IUserRepository _repository = repository;
    private readonly ILogger<GetAllUsersHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Select(UserMappingProfiles.MapUsers())
                .OrderBy(i => i.Id)
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query all Users with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}
