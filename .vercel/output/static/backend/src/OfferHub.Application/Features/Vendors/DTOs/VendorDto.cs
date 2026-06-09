namespace OfferHub.Application.Features.Vendors.DTOs;

public record VendorDto(
    Guid Id,
    string Name,
    string NameAr,
    string? Description,
    string? DescriptionAr,
    string? LogoUrl,
    string? CoverImageUrl,
    string? Website,
    string? Phone,
    string? Email,
    string Status,
    Guid OwnerId,
    int BranchCount,
    int OfferCount,
    DateTime CreatedAt);

public record VendorDashboardDto(
    Guid VendorId,
    string VendorName,
    int TotalOffers,
    int ActiveOffers,
    int TotalViews,
    int TotalClaims,
    int TotalRedemptions,
    decimal ConversionRate,
    int TotalFavorites,
    string? SubscriptionPlan,
    DateTime? SubscriptionExpiresAt);
