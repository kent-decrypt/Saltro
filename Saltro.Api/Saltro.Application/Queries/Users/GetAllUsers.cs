using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetAllUsers(DataSourceRequest request) : IRequest<DataSourceResult>;

internal sealed class GetAllUsersHandler(IUserRepository repository) : IRequestHandler<GetAllUsers, DataSourceResult>
{
    private readonly IUserRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Select(UserMappingProfiles.MapUsers())
            .OrderBy(i => i.Id)
            .ToDataSourceResult(request.request);

        return Task.FromResult(query);
    }
}
