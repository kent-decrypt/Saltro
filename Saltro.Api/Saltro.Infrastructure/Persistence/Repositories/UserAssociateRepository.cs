using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class UserAssociateRepository(SaltroDbContext context) : IUserAssociateRepository
{
    private readonly SaltroDbContext _context = context;

    public async Task AddAsync(UserAssociate entity, CancellationToken cancellationToken = default)
    {
        await _context.UserAssociates.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(UserAssociate entity, CancellationToken cancellationToken = default)
    {
        _context.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public Task<UserAssociate?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserAssociate?> GetByUserIdAndAssociateId(int userId, int associateId, CancellationToken cancellationToken = default)
        => await _context.UserAssociates.FirstOrDefaultAsync(i => i.UserId == userId && i.AssociateId == associateId, cancellationToken);

    public IQueryable<UserAssociate> Query()
        => _context.UserAssociates.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(UserAssociate entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
