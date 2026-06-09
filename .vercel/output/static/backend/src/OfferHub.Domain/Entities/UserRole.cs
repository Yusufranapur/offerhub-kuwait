using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class UserRole : AuditableEntity
{
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }

    public User? User { get; private set; }
    public Role? Role { get; private set; }

    protected UserRole() { }

    public static UserRole Create(Guid userId, Guid roleId)
    {
        return new UserRole
        {
            UserId = userId,
            RoleId = roleId
        };
    }
}
