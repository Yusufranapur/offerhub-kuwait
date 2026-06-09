using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class Role : AuditableEntity
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }

    private readonly List<UserRole> _userRoles = new();
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();

    private readonly List<RolePermission> _rolePermissions = new();
    public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions.AsReadOnly();

    protected Role() { }

    public static Role Create(string name, string? description = null)
    {
        return new Role
        {
            Name = name,
            Description = description
        };
    }
}
