namespace Saltro.Domain.Entities;

public sealed partial class UserGroup : BaseEntity
{
    /// <summary>
    /// TODO: check uniqueId implementations
    /// </summary>
    /// <param name="name"></param>
    /// <param name="uniqueId"></param>
    /// <param name="allowDefaultIfAuto"></param>
    /// <param name="isCustom"></param>
    /// <returns></returns>
    public static UserGroup Create(string name, string uniqueId, bool allowDefaultIfAuto, bool isCustom)
    {
        var userGroup = new UserGroup()
        {
            Name = name,
            UniqueId = uniqueId,
            AllowDefaultIfAuto = allowDefaultIfAuto,
            IsCustom = isCustom
        };

        return userGroup;
    }

    /// <summary>
    /// Sets the <seealso cref="AllowDefaultIfAuto"/> to a specific value
    /// </summary>
    /// <param name="allowDefaultIfAuto"></param>
    /// <returns></returns>
    public UserGroup SetAllowDefaultIfAuto(bool allowDefaultIfAuto)
    {
        AllowDefaultIfAuto = allowDefaultIfAuto;

        return this;
    }

    /// <summary>
    /// Sets the <seealso cref="IsCustom"/> to a specific value
    /// </summary>
    /// <param name="isCustom"></param>
    /// <returns></returns>
    public UserGroup SetIsCustom(bool isCustom)
    {
        IsCustom = isCustom;

        return this;
    }
}
