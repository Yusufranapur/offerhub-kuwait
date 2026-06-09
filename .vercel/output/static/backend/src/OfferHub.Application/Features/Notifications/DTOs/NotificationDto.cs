namespace OfferHub.Application.Features.Notifications.DTOs;

public record NotificationDto(
    Guid Id,
    string Title,
    string? TitleAr,
    string Body,
    string? BodyAr,
    string Type,
    bool IsRead,
    string? Data,
    DateTime CreatedAt);
