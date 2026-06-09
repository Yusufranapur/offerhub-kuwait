namespace OfferHub.Application.Features.Admin.DTOs;

public record AdminDashboardDto(
    int TotalCustomers,
    int TotalVendors,
    int ActiveOffers,
    int ClaimsToday,
    int RedemptionsToday,
    decimal Revenue,
    int PendingVendorApprovals,
    int PendingOfferApprovals);

public record BannerDto(
    Guid Id,
    string? Title,
    string? TitleAr,
    string ImageUrl,
    string? TargetUrl,
    string Type,
    int SortOrder,
    bool IsActive,
    DateTime? StartDate,
    DateTime? EndDate);

public record CmsContentDto(
    Guid Id,
    string Key,
    string? Title,
    string? TitleAr,
    string Content,
    string? ContentAr,
    DateTime UpdatedAt);
