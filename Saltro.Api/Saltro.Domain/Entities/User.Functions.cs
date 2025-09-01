namespace Saltro.Domain.Entities;

public sealed partial class User : BaseEntity
{
    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="uniqueId"></param>
    /// <param name="name"></param>
    /// <param name="clientName"></param>
    /// <param name="address"></param>
    /// <param name="postCode"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    /// <param name="phone"></param>
    /// <param name="email"></param>
    /// <param name="token"></param>
    /// <param name="isAdmin"></param>
    /// <param name="isAuto"></param>
    /// <param name="deletedDate"></param>
    /// <param name="deliveryAddressId"></param>
    /// <param name="locationId"></param>
    /// <param name="userAssociate_UserId"></param>
    /// <param name="userAssociate_AssociateId"></param>
    /// <param name="isCustom"></param>
    /// <param name="hasCustomCategories"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="salt"></param>
    /// <param name="initialLogin"></param>
    /// <param name="clientGroupId"></param>
    /// <returns></returns>
    public static User Create(string? uniqueId, string? name, string? clientName, string? address, string? postCode, string? city, string? country,
        string? phone, string? email, string? token, bool isAdmin, bool isAuto, DateTime? deletedDate,
        string? deliveryAddressId, string? locationId, int? userAssociate_UserId, int? userAssociate_AssociateId, bool isCustom, bool hasCustomCategories, string? userName,
        string? password, string? salt, bool? initialLogin, int? clientGroupId)
    {
        // TODO: check uniqueId implementations and other default values the don't need to be in the create
        var user = new User()
        {
            UniqueId = uniqueId,
            Name = name,
            ClientName = clientName,
            Address = address,
            PostCode = postCode,
            City = city,
            Country = country,
            Phone = phone,
            Email = email,
            Token = token,
            IsAdmin = isAdmin,
            IsAuto = isAuto,
            DeletedDate = deletedDate,
            DeliveryAddressId = deliveryAddressId,
            LocationId = locationId,
            UserAssociate_UserId = userAssociate_UserId,
            UserAssociate_AssociateId = userAssociate_AssociateId,
            IsCustom = isCustom,
            HasCustomCategories = hasCustomCategories,
            UserName = userName,
            Password = password,
            Salt = salt,
            InitialLogin = initialLogin,
            ClientGroupId = clientGroupId,
        };

        return user;
    }

    public User SoftDelete()
    {
        DeletedDate = DateTime.Now;        

        return this;
    }
}
