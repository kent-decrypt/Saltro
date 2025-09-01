using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class UserGroupRepository(SaltroDbContext context) : IUserGroupRepository
{
    private readonly SaltroDbContext _context = context;
    public async Task AddAsync(UserGroup entity, CancellationToken cancellationToken = default)
    {
        await _context.UserGroups.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(UserGroup entity, CancellationToken cancellationToken = default)
    {
        _context.UserGroups.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<UserGroup?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.UserGroups.FirstOrDefaultAsync(i => i.UserGroupId == id, cancellationToken);

    public IQueryable<UserGroup> Query()
        => _context.UserGroups.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(UserGroup entity, CancellationToken cancellationToken = default)
    {
        _context.UserGroups.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
