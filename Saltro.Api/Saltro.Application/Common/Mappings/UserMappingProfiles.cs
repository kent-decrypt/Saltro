using UserEntity = Saltro.Domain.Entities.User;
using UserAssociateEntity = Saltro.Domain.Entities.UserAssociate;
using UserGroupEntity = Saltro.Domain.Entities.UserGroup;
using UserSubscriptionEntity = Saltro.Domain.Entities.UserSubscription;
using System.Linq.Expressions;
using Saltro.Application.DTO.Users;

namespace Saltro.Application.Common.Mappings;

internal static class UserMappingProfiles
{
    /// <summary>
    /// Maps the <seealso cref="UserEntity"/> to <seealso cref="User"/> DTO
    /// </summary>
    /// <returns></returns>
    internal static Expression<Func<UserEntity, User>> MapUsers()
    {
        return entity => new()
        {
            Id = entity.UserId,
            UniqueId = entity.UniqueId,
            Name = entity.Name,
            ClientName = entity.ClientName,
            Address = entity.Address,
            PostCode = entity.PostCode,
            City = entity.City,
            Country = entity.Country,
            Phone = entity.Phone,
            Email = entity.Email,
            IsAdmin = entity.IsAdmin,
            IsAuto = entity.IsAuto,
            DeletedDate = entity.DeletedDate,
            DeliveryAddressId = entity.DeliveryAddressId,
            LocationId = entity.LocationId,
            UserAssociate_UserId = entity.UserAssociate_UserId,
            UserAssociate_AssociateId = entity.UserAssociate_AssociateId,
            IsCustom = entity.IsCustom,
            HasCustomCategories = entity.HasCustomCategories,
            ClientGroupId = entity.ClientGroupId,
        };
    }

    /// <summary>
    /// Maps the <seealso cref="UserAssociateEntity"/> to <seealso cref="UserAssociate"/> DTO
    /// </summary>
    internal static Expression<Func<UserAssociateEntity, UserAssociate>> MapAssociates()
    {
        var userMap = MapUsers().Compile();

        return entity => new UserAssociate
        {
            User = userMap(entity.User),
            Associate = userMap(entity.Associate),
            User_UserId = entity.User_UserId,
            User_UserId1 = entity.User_UserId1
        };
    }

    /// <summary>
    /// Maps the <seealso cref="UserGroupEntity"/> to <seealso cref="UserGroup"/> DTO
    /// </summary>
    /// <returns></returns>
    internal static Expression<Func<UserGroupEntity, UserGroup>> MapUserGroups()
    {
        return entity => new()
        {
            Id = entity.UserGroupId,
            Name = entity.Name,
            UniqueId = entity.UniqueId,
            AllowDefaultIfAuto = entity.AllowDefaultIfAuto,
            IsCustom = entity.IsCustom
        };
    }

    /// <summary>
    /// Maps the <seealso cref="UserSubscriptionEntity"/> to <seealso cref="UserSubscription"/> DTO
    /// </summary>
    /// <returns></returns>
    internal static Expression<Func<UserSubscriptionEntity, UserSubscription>> MapSubscriptions()
    {
        var userMapper = MapUsers().Compile();

        return entity => new()
        {
            Id = entity.Id,
            User = userMapper(entity.User),
            Subscription = entity.Subscription,
            Opslag = entity.Opslag,
        };
    }
}
