using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblCartItems")]
public sealed partial class CartItem : BaseEntity
{
    private CartItem() { }

    [Key]
    public int CartItemId { get; private set; }
    public int CartId { get; private set; }
    public int CategoryId { get; private set; }
    public int ItemId { get; private set; }
    public int Quantity { get; private set; }
    public bool IsPackage { get; private set; }
    public decimal Price { get; private set; }
    public int SortOrder { get; private set; }

    [ForeignKey(nameof(CartItemId))]
    public Cart Cart { get; private set; } = default!;

    [ForeignKey(nameof(ItemId))]
    public Product Item { get; private set; } = default!;
}
