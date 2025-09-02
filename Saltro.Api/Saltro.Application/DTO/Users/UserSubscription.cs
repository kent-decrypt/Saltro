namespace Saltro.Application.DTO.Users;

public class UserSubscription
{
    public int Id { get; init; }
    public User User { get; init; } = default!;
    public string? Subscription { get; init; }
    public decimal? Opslag { get; init; }
}
