using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;
using Saltro.Domain.Repository;

namespace Saltro.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository(SaltroDbContext context) : IUserRepository
{
    private readonly SaltroDbContext _context = context;

    public IQueryable<User> Query() => _context.Users.AsNoTracking();
    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);
    }        

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        entity.SoftDelete();

        _context.Users.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Users.FirstOrDefaultAsync(i => i.UserId == id, cancellationToken);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
