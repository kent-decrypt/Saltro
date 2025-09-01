using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblCarts")]
public sealed partial class Cart : BaseEntity
{
    private Cart() { }

    [Key] 
    public int CartId { get; private set; }
    public int UserId { get; private set; }
    public bool IsSubmitted { get; private set; }
    public int CreatedBy { get; private set; }
    public string? CompositeId { get; private set; } = default!;
    public bool IsProcessed { get; private set; } = false;
    public bool IsProcessing { get; private set; } = false;
    public DateTime? ProcessStartDate { get; private set; }
    public DateTime? ProcessEndDate { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? DeletedDate { get; private set; }
    public DateTime? UpdatedDate { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; private set; } = default!;

    public ICollection<CartItem> CartItems { get; private set; } = [];
}
