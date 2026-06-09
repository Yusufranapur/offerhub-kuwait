namespace OfferHub.Domain.Entities;

public class UserRoleEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;

    private UserRoleEntity() { }

    public static UserRoleEntity Create(Guid userId, Guid roleId)
    {
        return new UserRoleEntity
        {
            UserId = userId,
            RoleId = roleId
        };
    }
}
