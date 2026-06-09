using System;
namespace OfferHub.Application.Features.Notifications;

public record NotificationDto(Guid Id, string Title, string TitleAr, string Body, string BodyAr, bool IsRead, DateTime CreatedAt);
