namespace Saltro.Application.DTO.Users;

public class UserGroup
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? UniqueId { get; init; }
    public bool AllowDefaultIfAuto { get; init; }
    public bool IsCustom { get; init; }
}
