namespace OfferHub.Application.Features.Staff.DTOs;

public record StaffDto(
    Guid Id,
    Guid VendorId,
    Guid UserId,
    string UserFullName,
    string UserEmail,
    string Role,
    DateTime CreatedAt);
