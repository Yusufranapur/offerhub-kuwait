using System;
namespace OfferHub.Application.Features.Branches;

public record BranchDto(Guid Id, Guid VendorId, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber);
