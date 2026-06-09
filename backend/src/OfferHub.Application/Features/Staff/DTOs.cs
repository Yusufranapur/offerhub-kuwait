using System;
namespace OfferHub.Application.Features.Staff;

public record StaffDto(Guid Id, Guid VendorId, Guid UserId, string Role);
