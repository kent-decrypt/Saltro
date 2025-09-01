using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class UserSubscriptionRepository(SaltroDbContext context) : IUserSubscriptionRepository
{
    private readonly SaltroDbContext _context = context;

    public async Task AddAsync(UserSubscription entity, CancellationToken cancellationToken = default)
    {
        await _context.UserSubscriptions.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(UserSubscription entity, CancellationToken cancellationToken = default)
    {
        _context.UserSubscriptions.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<UserSubscription?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.UserSubscriptions.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

    public IQueryable<UserSubscription> Query()
        => _context.UserSubscriptions.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(UserSubscription entity, CancellationToken cancellationToken = default)
    {
        _context.UserSubscriptions.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
