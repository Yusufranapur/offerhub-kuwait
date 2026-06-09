using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;

namespace OfferHub.Domain.Entities;

public class Notification : AuditableEntity
{
    public Guid UserId { get; private set; }
    public string Title { get; private set; } = null!;
    public string TitleAr { get; private set; } = null!;
    public string Message { get; private set; } = null!;
    public string MessageAr { get; private set; } = null!;
    public NotificationType Type { get; private set; }
    public bool IsRead { get; private set; }
    public string? ReferenceId { get; private set; }

    public User? User { get; private set; }

    protected Notification() { }

    public static Notification Create(Guid userId, string title, string titleAr, string message, string messageAr, NotificationType type, string? referenceId)
    {
        return new Notification
        {
            UserId = userId,
            Title = title,
            TitleAr = titleAr,
            Message = message,
            MessageAr = messageAr,
            Type = type,
            IsRead = false,
            ReferenceId = referenceId
        };
    }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}
