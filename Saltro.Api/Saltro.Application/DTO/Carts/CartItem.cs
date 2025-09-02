using Saltro.Application.DTO.Products;

namespace Saltro.Application.DTO.Carts;

public class CartItem(int cartId)
{
    public int Id { get; init; }
    public int CardId { get; } = cartId;
    public int CategoryId { get; init; }
    public Product Product { get; init; } = default!;
    public int Quantity { get; init; }
    public bool IsPackage { get; init; }
    public decimal Price { get; init; }
    public int SortOrder { get; init; }
}
