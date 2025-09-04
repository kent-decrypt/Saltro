using System.ComponentModel;

namespace Saltro.Application.Payloads;

/// <summary>
/// Payload for creating a new product
/// </summary>
public class CreateProductRequest
{
    [DisplayName("Burat")]
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int MaxQuantity { get; set; }
    public int? Type { get; set; }
    public string? ProductNo { get; set; }
    public bool IsFlag { get; set; } = false;
    public bool IsPackageOnly { get; set; } = false;
    public string? Subscription {  get; set; }
    public decimal SellPrice { get; set; } = 0.00M;
    public int SellVAT { get; set; } = 0;
    public string? ProductCode { get; set; }
    public string? CostCenter { get; set; }
    public string? CostDim1 { get; set; }
}
