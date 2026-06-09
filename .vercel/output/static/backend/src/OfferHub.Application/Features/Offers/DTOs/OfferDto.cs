namespace OfferHub.Application.Features.Offers.DTOs;

public record OfferDto(
    Guid Id,
    Guid VendorId,
    string? VendorName,
    string? VendorNameAr,
    string? VendorLogoUrl,
    Guid CategoryId,
    string? CategoryName,
    string? CategoryNameAr,
    string Title,
    string TitleAr,
    string? Description,
    string? DescriptionAr,
    string OfferType,
    decimal? DiscountValue,
    decimal? OriginalPrice,
    decimal? DiscountedPrice,
    string? CoverImageUrl,
    DateTime StartDate,
    DateTime EndDate,
    int? MaxClaims,
    int TotalClaims,
    bool IsFeatured,
    string Status,
    DateTime CreatedAt);

public record OfferDetailDto(
    Guid Id,
    Guid VendorId,
    string? VendorName,
    string? VendorNameAr,
    string? VendorLogoUrl,
    Guid CategoryId,
    string? CategoryName,
    string? CategoryNameAr,
    string Title,
    string TitleAr,
    string? Description,
    string? DescriptionAr,
    string OfferType,
    decimal? DiscountValue,
    decimal? OriginalPrice,
    decimal? DiscountedPrice,
    string? CoverImageUrl,
    DateTime StartDate,
    DateTime EndDate,
    int? MaxClaims,
    int TotalClaims,
    int TotalRedemptions,
    int ViewCount,
    bool IsFeatured,
    string Status,
    string? TermsAndConditions,
    string? TermsAndConditionsAr,
    string? RejectionReason,
    List<string> Images,
    List<OfferBranchDto> Branches,
    DateTime CreatedAt);

public record OfferBranchDto(
    Guid BranchId,
    string Name,
    string NameAr,
    string? Address,
    double? Latitude,
    double? Longitude);

public record ClaimResponse(
    Guid ClaimId,
    string CouponCode,
    string QrCodeData,
    DateTime ExpiresAt);

public record RedemptionResponse(
    Guid ClaimId,
    Guid OfferId,
    string OfferTitle,
    DateTime RedeemedAt,
    string Message);
