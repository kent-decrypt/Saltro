using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblProducts")]
public sealed partial class Product : BaseEntity
{
    private Product() { }

    [Key]
    public int ProductId { get; private set; }
    public string? UniqueId { get; private set; } = default!;
    public string? Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int MaxQuantity { get; private set; }
    public int? Type { get; private set; }
    public bool IsActive { get; private set; }
    public string? ProductNo { get; private set; } = default!;
    public bool IsFLag { get; private set; }
    public bool IsPackageOnly { get; private set; }
    public string? Subscription { get; private set; } = default!;
    public DateTime? DeletedDate { get; private set; }
    public bool IsNotOrderable { get; private set; }
    public decimal? SellPrice { get; private set; }
    public int? SellVAT { get; private set; }
    public string? ProductCode { get; private set; } = default!;
    public string? CostCenter { get; private set; } = default!;
    public string? CostDim1 { get; private set; } = default!;

    public ICollection<CartItem> CartItems { get; private set; } = [];
}
