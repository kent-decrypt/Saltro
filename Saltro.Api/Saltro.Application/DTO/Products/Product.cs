namespace Saltro.Application.DTO.Products;

public class Product
{
    public int Id { get; init; }
    public string UniqueId { get; init; } = null!;
    public string? Name { get; init; }
    public decimal Price { get; init; }
    public int MaxQuantity { get; init; }
    public string? ProductNo { get; init; }
    public bool IsFLag { get; init; }
    public bool IsPackageOnly { get; init; }
    public string? Subscription { get; init; }
    public bool IsNotOrderable { get; init; }
    public decimal? SellPrice { get; init; }
    public int? SellVAT { get; init; }
    public string? ProductCode { get; init; }
    public string? CostCenter { get; init; }
    public string? CostDim1 { get; init; }
}