namespace Saltro.Domain.Entities;

public sealed partial class UserGroupsMapping
{
    /// <summary>
    /// Creates a new UserGroupsMapping entity that will be ready for saving
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userGroupdId"></param>
    /// <returns></returns>
    public static UserGroupsMapping Create(int userId, int userGroupdId)
    {
        var userGroupMapping = new UserGroupsMapping() { UserId = userId, UserGroupId = userGroupdId };

        return userGroupMapping;
    }

    /// <summary>
    /// Creates a new UserGroupsMapping entity that will be ready for saving
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userGroup"></param>
    /// <returns></returns>
    public static UserGroupsMapping Create(int userId, UserGroup userGroup)
    {
        var userGroupMapping = new UserGroupsMapping() { UserId = userId, UserGroup = userGroup };

        return userGroupMapping;
    }

    /// <summary>
    /// Creates a new UserGroupsMapping entity that will be ready for saving
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userGroupId"></param>
    /// <returns></returns>
    public static UserGroupsMapping Create(User user, int userGroupId)
    {
        var userGroupMapping = new UserGroupsMapping() { User = user, UserGroupId = userGroupId };

        return userGroupMapping;
    }

    /// <summary>
    /// Creates a new UserGroupsMapping entity that will be ready for saving
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userGroup"></param>
    /// <returns></returns>
    public static UserGroupsMapping Create(User user, UserGroup userGroup)
    {
        var userGroupMapping = new UserGroupsMapping() { User = user, UserGroup = userGroup };

        return userGroupMapping;
    }
}
