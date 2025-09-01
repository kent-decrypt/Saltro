using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblUsers")]
public sealed partial class User : BaseEntity
{
    private User() { }

    [Key]
    public int UserId { get; private set; }
    public string? UniqueId { get; private set; } = default!;
    public string? Name { get; private set; } = default!;
    public string? ClientName { get; private set; } = default!;
    public string? Address { get; private set; } = default!;
    public string? PostCode { get; private set; } = default!;
    public string? City { get; private set; } = default!;
    public string? Country { get; private set; } = default!;
    public string? Phone { get; private set; } = default!;
    public string? Email { get; private set; } = default!;
    public string? Token { get; private set; } = default!;
    public bool IsAdmin { get; private set; }
    public bool IsAuto { get; private set; }
    public DateTime? DeletedDate { get; private set; }
    public string? DeliveryAddressId { get; private set; } = default!;
    public string? LocationId { get; private set; } = default!;
    public int? UserAssociate_UserId { get; private set; }
    public int? UserAssociate_AssociateId { get; private set; }
    public bool IsCustom { get; private set; }
    public bool HasCustomCategories { get; private set; }
    public string? UserName { get; private set; } = default!;
    public string? Password { get; private set; } = default!;
    public string? Salt { get; private set; } = default!;
    public bool? InitialLogin { get; private set; }
    public int? ClientGroupId { get; private set; }

    public ICollection<UserAssociate> UserAssociates { get; private set; } = [];
    public ICollection<UserAssociate> Associates { get; private set; } = [];
    public ICollection<UserAssociate> User_UserIds { get; private set; } = [];
    public ICollection<UserAssociate> User_UserId1s { get; private set; } = [];
    public ICollection<UserGroupsMapping> UserGroupsMappings { get; private set; } = [];
    public ICollection<Cart> Carts { get; private set; } = [];
}
