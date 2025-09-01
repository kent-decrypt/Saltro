namespace Saltro.Application.DTO.Carts;

public class Cart
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public bool IsSubmitted { get; init; }
    public int CreatedBy { get; init; }
    public string? CompositeId { get; init; }
    public bool IsProcessed { get; init; }
    public bool IsProcessing { get; init; }
    public DateTime? ProcessStartDate { get; init; }
    public DateTime? ProcessEndDate { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime? DeletedDate { get; init; }
    public DateTime? UpdatedDate { get; init; }
}