using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class Permission : AuditableEntity
{
    public string Name { get; private set; } = null!;
    public string SystemName { get; private set; } = null!;
    public string? Group { get; private set; }

    protected Permission() { }

    public static Permission Create(string name, string systemName, string? group = null)
    {
        return new Permission
        {
            Name = name,
            SystemName = systemName,
            Group = group
        };
    }
}
