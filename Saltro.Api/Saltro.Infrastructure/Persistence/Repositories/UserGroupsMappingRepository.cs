using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class UserGroupsMappingRepository(SaltroDbContext context) : IUserGroupsMappingRepository
{
    private readonly SaltroDbContext _context = context;

    public async Task AddAsync(UserGroupsMapping entity, CancellationToken cancellationToken = default)
    {
        await _context.UserGroupsMappings.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(UserGroupsMapping entity, CancellationToken cancellationToken = default)
    {
        _context.UserGroupsMappings.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public Task<UserGroupsMapping?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserGroupsMapping?> GetByUserIdAndUserGroupIdAsync(int userId, int userGroupId, CancellationToken cancellationToken = default)
        => await _context.UserGroupsMappings.FirstOrDefaultAsync(i => i.UserId == userId && i.UserGroupId == userGroupId, cancellationToken);

    public IQueryable<UserGroupsMapping> Query()
        => _context.UserGroupsMappings.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(UserGroupsMapping entity, CancellationToken cancellationToken = default)
    {
        _context.UserGroupsMappings.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
