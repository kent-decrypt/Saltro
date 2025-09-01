using Saltro.Domain.Entities;

namespace Saltro.Domain.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Queries a list of <typeparamref name="TEntity"/>
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> Query();

    /// <summary>
    /// Retrieves a specific data of <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates and saves an instance of <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates and saves a specific record of <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes and saves a specific record of <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves any change related to the DatabaseContext
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
