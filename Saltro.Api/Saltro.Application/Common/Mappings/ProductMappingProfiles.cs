using ProductEntity = Saltro.Domain.Entities.Product;
using System.Linq.Expressions;
using Saltro.Application.DTO.Products;

namespace Saltro.Application.Common.Mappings;

internal static class ProductMappingProfiles
{
    internal static Expression<Func<ProductEntity, Product>> MapProducts()
    {
        return entity => new Product
        {
            Id = entity.ProductId,
            Name = entity.Name,
            UniqueId = entity.UniqueId!,
            Price = entity.Price,
            MaxQuantity = entity.MaxQuantity,
            ProductNo = entity.ProductNo,
            IsFLag = entity.IsFLag,
            IsPackageOnly = entity.IsPackageOnly,
            Subscription = entity.Subscription,
            IsNotOrderable = entity.IsNotOrderable,
            SellPrice = entity.SellPrice,
            SellVAT = entity.SellVAT,
            ProductCode = entity.ProductCode,
            CostCenter = entity.CostCenter,
            CostDim1 = entity.CostDim1,
        };
    }
}