using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saltro.Application.Common.Mappings;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetUserAssociates(DataSourceRequest request) : IRequest<DataSourceResult>;

internal sealed class GetUserAssociatesHandler(IUserAssociateRepository repository) : IRequestHandler<GetUserAssociates, DataSourceResult>
{
    private readonly IUserAssociateRepository _repository = repository;

    public Task<DataSourceResult> Handle(GetUserAssociates request, CancellationToken cancellationToken)
    {
        var query = _repository
            .Query()
            .Include(i => i.User)
            .Include(i => i.Associate)
            .Select(UserMappingProfiles.MapAssociates())
            .ToDataSourceResult(request.request);

        return Task.FromResult(query);
    }
}