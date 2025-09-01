using CartEntity = Saltro.Domain.Entities.Cart;
using System.Linq.Expressions;
using Saltro.Application.DTO.Carts;

namespace Saltro.Application.Common.Mappings;

internal static class CartMappingProfiles
{
    internal static Expression<Func<CartEntity, Cart>> MapCarts()
    {
        return entity => new()
        {
            Id = entity.CartId,
            UserId = entity.UserId,
            IsSubmitted = entity.IsSubmitted,
            CreatedBy = entity.CreatedBy,
            CompositeId = entity.CompositeId,
            IsProcessed = entity.IsProcessed,
            IsProcessing = entity.IsProcessing,
            ProcessStartDate = entity.ProcessStartDate,
            ProcessEndDate = entity.ProcessEndDate,
            CreatedDate = entity.CreatedDate,
            DeletedDate = entity.DeletedDate,
            UpdatedDate = entity.UpdatedDate
        };
    }
}