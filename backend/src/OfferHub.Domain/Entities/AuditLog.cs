using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class AuditLog : BaseEntity
{
    public string Action { get; private set; } = null!;
    public string EntityName { get; private set; } = null!;
    public string EntityId { get; private set; } = null!;
    public Guid? UserId { get; private set; }
    public string? OldValues { get; private set; }
    public string? NewValues { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }

    protected AuditLog() { }

    public static AuditLog Create(string action, string entityName, string entityId, Guid? userId, string? oldValues, string? newValues)
    {
        return new AuditLog
        {
            Action = action,
            EntityName = entityName,
            EntityId = entityId,
            UserId = userId,
            OldValues = oldValues,
            NewValues = newValues,
            Timestamp = DateTimeOffset.UtcNow
        };
    }
}
