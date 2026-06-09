namespace OfferHub.Application.Features.Categories.DTOs;

public record CategoryDto(
    Guid Id,
    string Name,
    string NameAr,
    string? IconUrl,
    string? ImageUrl,
    int SortOrder,
    bool IsActive,
    int OfferCount);
