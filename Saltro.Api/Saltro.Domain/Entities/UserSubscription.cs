using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblUserSubscriptions")]
public sealed partial class UserSubscription
{
    private UserSubscription() { }

    [Key]
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string? Subscription { get; private set; } = default!;
    public decimal? Opslag { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; private set; } = default!;
}
