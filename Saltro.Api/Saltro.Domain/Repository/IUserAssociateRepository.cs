using Saltro.Domain.Entities;

namespace Saltro.Domain.Repository;

public interface IUserAssociateRepository : IBaseRepository<UserAssociate>
{
    /// <summary>
    /// Retrieves a UserAssociate record using userId and associateId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="associateId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserAssociate?> GetByUserIdAndAssociateId(int userId, int associateId, CancellationToken cancellationToken = default);
}
