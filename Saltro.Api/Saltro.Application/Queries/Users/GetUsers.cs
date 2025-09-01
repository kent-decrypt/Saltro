using KendoNET.DynamicLinq;
using MediatR;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetUsers(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetUsersHandler(IUserRepository repository) : IRequestHandler<GetUsers, DataSourceResult>
{
    private readonly IUserRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Where(i => i.DeletedDate == null)
            .Select(UserMappingProfiles.MapUsers())
            .OrderBy(i => i.Id)
            .ToDataSourceResult(request.Request);

        return Task.FromResult(query);
    }
}
