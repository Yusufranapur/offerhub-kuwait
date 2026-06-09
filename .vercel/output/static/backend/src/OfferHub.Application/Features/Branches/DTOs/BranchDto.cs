namespace OfferHub.Application.Features.Branches.DTOs;

public record BranchDto(
    Guid Id,
    Guid VendorId,
    string Name,
    string NameAr,
    string? Address,
    string? AddressAr,
    double? Latitude,
    double? Longitude,
    string? Phone,
    string? WorkingHours,
    bool IsActive);
