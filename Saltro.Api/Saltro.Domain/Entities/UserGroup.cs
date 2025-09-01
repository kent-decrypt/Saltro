using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblUserGroups")]
public sealed partial class UserGroup : BaseEntity
{
    private UserGroup() { }

    [Key]
    public int UserGroupId { get; private set; }
    public string? Name { get; private set; } = default!;
    public string? UniqueId { get; private set; } = default!;
    public bool AllowDefaultIfAuto { get; private set; }
    public bool IsCustom { get; private set; }

    public ICollection<UserGroupsMapping> UserGroupsMappings { get; private set; } = [];
}
