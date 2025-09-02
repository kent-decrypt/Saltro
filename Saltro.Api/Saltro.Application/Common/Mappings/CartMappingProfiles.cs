using CartEntity = Saltro.Domain.Entities.Cart;
using CartItemEntity = Saltro.Domain.Entities.CartItem;
using System.Linq.Expressions;
using Saltro.Application.DTO.Carts;

namespace Saltro.Application.Common.Mappings;

internal static class CartMappingProfiles
{
    /// <summary>
    /// Maps the <seealso cref="CartEntity"/> CartItem Entity to <seealso cref="Cart"/> DTO
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Maps the <seealso cref="CartItemEntity"/> CartItem Entity to <seealso cref="CartItem"/> DTO
    /// </summary>
    /// <param name="cartId"></param>
    /// <returns></returns>
    internal static Expression<Func<CartItemEntity, CartItem>> MapCartItems(int cartId)
    {
        var productMapper = ProductMappingProfiles.MapProducts().Compile();

        return entity => new(cartId)
        {
            Id = entity.CartItemId,
            CategoryId = entity.CategoryId,
            Product = productMapper(entity.Item),
            Quantity = entity.Quantity,
            IsPackage = entity.IsPackage,
            Price = entity.Price,
            SortOrder = entity.SortOrder
        };
    }
}