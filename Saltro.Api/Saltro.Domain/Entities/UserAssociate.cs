using System.ComponentModel.DataAnnotations.Schema;

namespace Saltro.Domain.Entities;

[Table("TblUserAssociates")]
public sealed partial class UserAssociate : BaseEntity
{
    private UserAssociate() { }

    public int UserId { get; private set; }
    public int AssociateId { get; private set; }
    public int? User_UserId { get; private set; }
    public int? User_UserId1 { get; private set; }


    [ForeignKey(nameof(UserId))]
    public User User { get; private set; } = default!;

    [ForeignKey(nameof(AssociateId))]
    public User Associate { get; private set; } = default!;

    [ForeignKey(nameof(User_UserId))]
    public User User_User { get; private set; } = default!;

    [ForeignKey(nameof(User_UserId1))]
    public User User_User1 { get; private set; } = default!;
}
