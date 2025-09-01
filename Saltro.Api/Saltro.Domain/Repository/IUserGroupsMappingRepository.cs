using Saltro.Domain.Entities;

namespace Saltro.Domain.Repository;

public interface IUserGroupsMappingRepository : IBaseRepository<UserGroupsMapping>
{
    /// <summary>
    /// Retrieves a UserGroupsMapping record using userId and userGroupId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userGroupId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserGroupsMapping?> GetByUserIdAndUserGroupIdAsync(int userId, int userGroupId, CancellationToken cancellationToken = default);
}
