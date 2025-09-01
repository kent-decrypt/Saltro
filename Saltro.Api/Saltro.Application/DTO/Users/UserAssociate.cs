namespace Saltro.Application.DTO.Users;

public class UserAssociate
{
    public User User { get; init; } = default!;
    public User Associate { get; init; } = default!;
    public int? User_UserId { get; init; }
    public int? User_UserId1 { get; init; }
}