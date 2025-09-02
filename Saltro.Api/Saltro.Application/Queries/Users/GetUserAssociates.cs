using KendoNET.DynamicLinq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saltro.Application.Common.Mappings;
using Saltro.Application.Exceptions;
using Saltro.Domain.Repository;

namespace Saltro.Application.Queries.Users;

public record GetUserAssociates(DataSourceRequest Request) : IRequest<DataSourceResult>;

internal sealed class GetUserAssociatesHandler(IUserAssociateRepository repository, ILogger<GetUserAssociatesHandler> logger) : IRequestHandler<GetUserAssociates, DataSourceResult>
{
    private readonly IUserAssociateRepository _repository = repository;
    private readonly ILogger<GetUserAssociatesHandler> _logger = logger;

    public Task<DataSourceResult> Handle(GetUserAssociates request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .Query()
                .Include(i => i.User)
                .Include(i => i.Associate)
                .Select(UserMappingProfiles.MapAssociates())
                .ToDataSourceResult(request.Request);

            return Task.FromResult(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Query User Associates with exception: {ex}", ex);
            throw ProblemDetailsException.InternalServerException("There was a problem with your request");
        }
    }
}