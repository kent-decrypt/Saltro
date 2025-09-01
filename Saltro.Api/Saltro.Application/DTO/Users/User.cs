namespace Saltro.Application.DTO.Users;

/// <summary>
/// Represents the User data
/// </summary>
public class User
{
    public int Id { get; init; }
    public string? UniqueId { get; init; } = default!;
    public string? Name { get; init; } = default!;
    public string? ClientName { get; init; } = default!;
    public string? Address { get; init; } = default!;
    public string? PostCode { get; init; } = default!;
    public string? City { get; init; } = default!;
    public string? Country { get; init; } = default!;
    public string? Phone { get; init; } = default!;
    public string? Email { get; init; } = default!;
    public string? Token { get; init; } = default!;
    public bool IsAdmin { get; init; }
    public bool IsAuto { get; init; }
    public DateTime? DeletedDate { get; init; }
    public string? DeliveryAddressId { get; init; } = default!;
    public string? LocationId { get; init; } = default!;
    public int? UserAssociate_UserId { get; init; }
    public int? UserAssociate_AssociateId { get; init; }
    public bool IsCustom { get; init; }
    public bool HasCustomCategories { get; init; }
    public int? ClientGroupId { get; init; }
}
