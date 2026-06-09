using System;
namespace OfferHub.Application.Features.Subscriptions;

public record SubscriptionPlanDto(Guid Id, string Name, string NameAr, decimal Price, int DurationInDays, int MaxOffers);
public record VendorSubscriptionDto(Guid Id, Guid VendorId, Guid PlanId, DateTime StartDate, DateTime EndDate, bool IsActive);
public record PaymentHistoryDto(Guid Id, Guid VendorId, decimal Amount, string Currency, DateTime PaymentDate, string Status);
