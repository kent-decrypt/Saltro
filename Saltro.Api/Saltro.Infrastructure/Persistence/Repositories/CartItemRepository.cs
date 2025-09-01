using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class CartItemRepository(SaltroDbContext context) : ICartItemRepository
{
    private readonly SaltroDbContext _context = context;

    public async Task AddAsync(CartItem entity, CancellationToken cancellationToken = default)
    {
        await _context.CartItems.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(CartItem entity, CancellationToken cancellationToken = default)
    {
        _context.CartItems.Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<CartItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.CartItems.FirstOrDefaultAsync(i => i.CartItemId == id, cancellationToken);

    public IQueryable<CartItem> Query()
        => _context.CartItems.AsNoTracking();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(CartItem entity, CancellationToken cancellationToken = default)
    {
        _context.CartItems.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
