namespace OfferHub.Application.Features.Subscriptions.DTOs;

public record SubscriptionPlanDto(
    Guid Id,
    string Name,
    string NameAr,
    string? Description,
    string? DescriptionAr,
    decimal Price,
    string Currency,
    int DurationDays,
    int MaxOffers,
    int MaxBranches,
    string? Features,
    bool IsActive);

public record VendorSubscriptionDto(
    Guid Id,
    Guid VendorId,
    string PlanName,
    string PlanNameAr,
    string Status,
    DateTime StartDate,
    DateTime EndDate,
    bool AutoRenew,
    DateTime CreatedAt);

public record PaymentDto(
    Guid Id,
    Guid VendorId,
    decimal Amount,
    string Currency,
    string Status,
    string? TransactionRef,
    string? PaymentMethod,
    DateTime? PaidAt,
    DateTime CreatedAt);
