using System;
namespace OfferHub.Application.Features.Vendors;

public record VendorDto(Guid Id, string Name, string NameAr, string Description, string DescriptionAr, string LogoUrl, string ContactEmail, string ContactPhone);
public record VendorDashboardDto(int TotalOffers, int ActiveOffers, int TotalRedemptions, decimal TotalRevenue);
