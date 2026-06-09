using System;
namespace OfferHub.Application.Features.Admin;

public record DashboardStatsDto(int TotalUsers, int TotalVendors, int ActiveOffers, decimal TotalRevenue);
public record AnalyticsDto(int DailyActiveUsers, int WeeklyActiveUsers, int TotalRedemptions);
