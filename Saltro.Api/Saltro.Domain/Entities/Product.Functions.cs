namespace Saltro.Domain.Entities;

public sealed partial class Product : BaseEntity
{
    /// <summary>
    /// TODO: check uniqueId implementations and also other things that should be generated automatically
    /// </summary>
    /// <param name="uniqueId"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="maxQuantity"></param>
    /// <param name="type"></param>
    /// <param name="productNo"></param>
    /// <param name="isFLag"></param>
    /// <param name="isPackageOnly"></param>
    /// <param name="subscription"></param>
    /// <param name="isNotOrderable"></param>
    /// <param name="sellPrice"></param>
    /// <param name="sellVAT"></param>
    /// <param name="productCode"></param>
    /// <param name="costCenter"></param>
    /// <param name="costDim1"></param>
    /// <returns></returns>
    public static Product Create(string uniqueId, string name, decimal price, int maxQuantity, int type,
        string productNo, bool isFLag, bool isPackageOnly, string subscription, bool isNotOrderable, 
        decimal sellPrice, int sellVAT, string productCode, string costCenter, string costDim1)
    { 
        var product = new Product()
        {
            UniqueId = uniqueId,
            Name = name,
            Price = price,
            MaxQuantity = maxQuantity,
            Type = type,
            IsActive = true,
            ProductNo = productNo,
            IsFLag = isFLag,
            IsPackageOnly = isPackageOnly,
            Subscription = subscription,
            IsNotOrderable = isNotOrderable,
            SellPrice = sellPrice,
            SellVAT = sellVAT,
            ProductCode = productCode,
            CostCenter = costCenter,
            CostDim1 = costDim1
        };

        return product;
    }
}
