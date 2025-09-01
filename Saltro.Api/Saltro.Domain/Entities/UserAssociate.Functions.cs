namespace Saltro.Domain.Entities;

public sealed partial class UserAssociate : BaseEntity
{
    /// <summary>
    /// Creates a new UserAssociate entity
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="associateId"></param>
    /// <param name="user_UserId"></param>
    /// <param name="user_UserId1"></param>
    /// <returns></returns>
    public static UserAssociate Create(int userId, int associateId, int? user_UserId = null, int? user_UserId1 = null)
    {
        var userAssociate = new UserAssociate()
        {
            UserId = userId,
            AssociateId = associateId,
            User_UserId = user_UserId,
            User_UserId1 = user_UserId,
        };

        return userAssociate;
    }

    /// <summary>
    /// Sets the <seealso cref="User_UserId"/> to a specific value
    /// </summary>
    /// <param name="user_UserId1"></param>
    /// <returns></returns>
    public UserAssociate SetUser_UserId(int user_UserId1)
    {
        User_UserId = user_UserId1;

        return this;
    } 

    /// <summary>
    /// Sets the <seealso cref="User_UserId1"/> to a specific value
    /// </summary>
    /// <param name="user_UserId1"></param>
    /// <returns></returns>
    public UserAssociate SetUser_UserId1(int user_UserId1)
    {
        User_UserId1 = user_UserId1;

        return this;
    }
}
