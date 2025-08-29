namespace Saltro.Domain.Entities;

public sealed partial class UserGroup
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
}
