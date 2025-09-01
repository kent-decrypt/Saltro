namespace Saltro.Domain.Entities;

public sealed partial class CartItem : BaseEntity
{
    /// <summary>
    /// Creates a new CartItem entity that will be ready for saving
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="itemId"></param>
    /// <param name="categoryId"></param>
    /// <param name="quantity"></param>
    /// <param name="isPackage"></param>
    /// <param name="price"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static CartItem Create(int cartId, int itemId, int categoryId, int quantity,
        bool isPackage, decimal price, int sortOrder)
    {
        var cartItem = new CartItem()
        {
            CartId = cartId,
            ItemId = itemId,
            CategoryId = categoryId,
            Quantity = quantity,
            IsPackage = isPackage,
            Price = price,
        };

        return cartItem;
    }

    /// <summary>
    /// Creates a new CartItem entity that will be ready for saving
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="itemId"></param>
    /// <param name="categoryId"></param>
    /// <param name="quantity"></param>
    /// <param name="isPackage"></param>
    /// <param name="price"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static CartItem Create(Cart cart, int itemId, int categoryId, int quantity,
        bool isPackage, decimal price, int sortOrder)
    {
        var cartItem = new CartItem()
        {
            Cart = cart,
            ItemId = itemId,
            CategoryId = categoryId,
            Quantity = quantity,
            IsPackage = isPackage,
            Price = price,
        };

        return cartItem;
    }

    /// <summary>
    /// Creates a new CartItem entity that will be ready for saving
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="item"></param>
    /// <param name="categoryId"></param>
    /// <param name="quantity"></param>
    /// <param name="isPackage"></param>
    /// <param name="price"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static CartItem Create(int cartId, Product item, int categoryId, int quantity,
        bool isPackage, decimal price, int sortOrder)
    {
        var cartItem = new CartItem()
        {
            CartId = cartId,
            Item = item,
            CategoryId = categoryId,
            Quantity = quantity,
            IsPackage = isPackage,
            Price = price,
        };

        return cartItem;
    }

    /// <summary>
    /// Creates a new CartItem entity that will be ready for saving
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="item"></param>
    /// <param name="categoryId"></param>
    /// <param name="quantity"></param>
    /// <param name="isPackage"></param>
    /// <param name="price"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static CartItem Create(Cart cart, Product item, int categoryId, int quantity,
        bool isPackage, decimal price, int sortOrder)
    {
        var cartItem = new CartItem()
        {
            Cart = cart,
            Item = item,
            CategoryId = categoryId,
            Quantity = quantity,
            IsPackage = isPackage,
            Price = price,
        };

        return cartItem;
    }

    /// <summary>
    /// Updates the cart <seealso cref="Quantity"/> and <seealso cref="Price"/>
    /// </summary>
    /// <param name="newQuantity"></param>
    /// <param name="newPrice"></param>
    /// <returns></returns>
    public CartItem UpdateQuantity(int newQuantity, decimal newPrice)
    {
        Quantity = newQuantity;
        Price = newPrice;

        return this;
    }

    /// <summary>
    /// Sets the <seealso cref="IsPackage"/> to a specific value
    /// </summary>
    /// <param name="isPackage"></param>
    /// <returns></returns>
    public CartItem SetIsPackage(bool isPackage)
    {
        IsPackage = isPackage;

        return this;
    }

    /// <summary>
    /// Sets the <seealso cref="CategoryId"/> to a specific value
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public CartItem SetCategoryId(int categoryId)
    {
        CategoryId = categoryId;

        return this;
    }

    /// <summary>
    /// Sets the <seealso cref="SortOrder"/> to a specific value
    /// </summary>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public CartItem SetSortOrder(int sortOrder)
    {
        SortOrder = sortOrder;

        return this;
    }
}
