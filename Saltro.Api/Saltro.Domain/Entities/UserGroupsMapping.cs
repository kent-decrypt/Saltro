using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblUserUserGroups")]
public sealed partial class UserGroupsMapping
{
    private UserGroupsMapping() { }

    public int UserId { get; private set; }
    public int UserGroupId { get; private set; }


    [ForeignKey(nameof(UserId))]
    public User User { get; private set; } = default!;

    [ForeignKey(nameof(UserGroupId))]
    public UserGroup UserGroup { get; private set; } = default!;
}
