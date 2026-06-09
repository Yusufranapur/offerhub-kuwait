namespace OfferHub.Application.Features.Favorites.DTOs;

public record FavoriteDto(
    Guid Id,
    Guid OfferId,
    string? OfferTitle,
    string? OfferTitleAr,
    string? VendorName,
    string? VendorNameAr,
    string? CoverImageUrl,
    DateTime CreatedAt);
