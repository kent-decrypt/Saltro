using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class CartRepository(SaltroDbContext context) : ICartRepository
{
    private readonly SaltroDbContext _context = context;

    public async Task AddAsync(Cart entity, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Cart entity, CancellationToken cancellationToken = default)
    {
        _context.Carts.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Carts.FirstOrDefaultAsync(i => i.CartId == id, cancellationToken);

    public IQueryable<Cart> Query()
        => _context.Carts.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(Cart entity, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
