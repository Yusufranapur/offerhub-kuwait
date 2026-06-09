namespace OfferHub.Application.Features.Wallet.DTOs;

public record CouponDto(
    Guid Id,
    Guid OfferId,
    string? OfferTitle,
    string? OfferTitleAr,
    string? VendorName,
    string? VendorNameAr,
    string CouponCode,
    string QrCodeData,
    string Status,
    DateTime ClaimedAt,
    DateTime? RedeemedAt,
    DateTime ExpiresAt);
