namespace Saltro.Domain.Entities;

public sealed partial class Cart : BaseEntity
{
    /// <summary>
    /// Creates a new draft Cart entity that will be ready for saving
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="createdBy"></param>
    /// <param name="compositeId"></param>
    /// <returns></returns>
    public static Cart DraftCart(int userId, int createdBy, string? compositeId)
    {
        var cart = new Cart()
        {
            UserId = userId,
            IsSubmitted = false,
            CreatedBy = createdBy,
            CompositeId = compositeId,
            CreatedDate = DateTime.Now,
            DeletedDate = null,
            UpdatedDate = null,
        };

        return cart;
    }

    /// <summary>
    /// Creates a new draft Cart entity that will be ready for saving
    /// </summary>
    /// <param name="user"></param>
    /// <param name="createdBy"></param>
    /// <param name="compositeId"></param>
    /// <returns></returns>
    public static Cart DraftCart(User user, int createdBy, string? compositeId)
    {
        var cart = new Cart()
        {
            User = user,
            IsSubmitted = false,
            CreatedBy = createdBy,
            CompositeId = compositeId,
            CreatedDate = DateTime.Now,
            DeletedDate = null,
            UpdatedDate = null,
        };

        return cart;
    }

    /// <summary>
    /// Adds a new cart item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public Cart AddItem(CartItem item)
    {
        var existingItem = CartItems.Any(i => i.ItemId == i.ItemId);

        if(!existingItem)
        {
            CartItems.Add(item);
        }

        return this;
    }

    /// <summary>
    /// Updates the cart item quantity and its price
    /// </summary>
    /// <param name="cartItem"></param>
    /// <param name="newQuantity"></param>
    /// <param name="newPrice"></param>
    /// <returns></returns>
    public Cart UpdateCartItemQuantity(CartItem cartItem, int newQuantity, decimal newPrice)
    {
        var existingCartItem = CartItems.FirstOrDefault(i => i.CartItemId == cartItem.CartItemId);

        existingCartItem?.UpdateQuantity(newQuantity, newPrice);

        return this;
    }

    /// <summary>
    /// Updates the cart item quantity and its price
    /// </summary>
    /// <param name="cartItemId"></param>
    /// <param name="newQuantity"></param>
    /// <param name="newPrice"></param>
    /// <returns></returns>
    public Cart UpdateCartItemQuantity(int cartItemId, int newQuantity, decimal newPrice)
    {
        var cartItem = CartItems.FirstOrDefault(i => i.CartItemId == cartItemId);

        cartItem?.UpdateQuantity(newQuantity, newPrice);

        return this;
    }

    /// <summary>
    /// Removes an existing cart item
    /// </summary>
    /// <param name="cartItem"></param>
    /// <returns></returns>
    public Cart RemoveCartItem(CartItem cartItem)
    {
        var existingCartItem = CartItems.FirstOrDefault(i => i.CartItemId == cartItem.CartItemId);
        if (existingCartItem != null)
        {
            CartItems.Remove(existingCartItem);
        }

        return this;
    }

    /// <summary>
    /// Removes an existing cart item
    /// </summary>
    /// <param name="cartItemId"></param>
    /// <returns></returns>
    public Cart RemoveCartItem(int cartItemId)
    {
        var existingCartItem = CartItems.FirstOrDefault(i => i.CartItemId == cartItemId);
        if (existingCartItem != null)
        {
            CartItems.Remove(existingCartItem);
        }

        return this;
    }

    /// <summary>
    /// Marks the cart as submitted
    /// </summary>
    /// <returns></returns>
    public Cart Submit()
    {
        if (!IsSubmitted)
        {
            IsSubmitted = true;
            UpdatedDate = DateTime.Now;
        }

        return this;
    }

    /// <summary>
    /// Deletes the cart record (soft delete)
    /// </summary>
    /// <returns></returns>
    public Cart Delete()
    {
        if (DeletedDate != null) 
        {
            DeletedDate = DateTime.Now;
        }

        return this;
    }

    /// <summary>
    /// Cart starts being processed
    /// </summary>
    /// <returns></returns>
    public Cart StartProcessing()
    {
        if (!IsProcessed && !IsProcessing)
        {
            IsProcessing = true;
            ProcessStartDate = DateTime.Now;
            ProcessEndDate = null;

            UpdatedDate = DateTime.Now;
        }

        return this;
    }

    /// <summary>
    /// Cart is finished processing
    /// </summary>
    /// <returns></returns>
    public Cart EndProcessing()
    {
        if (IsProcessing && !IsProcessed)
        {
            IsProcessing = false;
            IsProcessed = true;
            ProcessEndDate = DateTime.Now;

            UpdatedDate = DateTime.Now;
        }

        return this;
    }

    /// <summary>
    /// Cancels processing the cart
    /// </summary>
    /// <returns></returns>
    public Cart StopProcessing()
    {
        if (IsProcessing && !IsProcessed)
        {
            IsProcessing = false;
            ProcessStartDate = null;
            ProcessEndDate = null;

            UpdatedDate = DateTime.Now;
        }

        return this;
    }
}
