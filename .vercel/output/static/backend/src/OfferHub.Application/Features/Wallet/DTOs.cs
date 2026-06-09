using System;
namespace OfferHub.Application.Features.Wallet;

public record CouponDto(Guid Id, Guid OfferId, string Code, DateTime ExpiryDate, bool IsRedeemed, DateTime? RedeemedAt);
