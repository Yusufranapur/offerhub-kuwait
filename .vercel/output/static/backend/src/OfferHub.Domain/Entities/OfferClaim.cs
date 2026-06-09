using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;
using OfferHub.Domain.ValueObjects;
using OfferHub.Domain.Events;

namespace OfferHub.Domain.Entities;

public class OfferClaim : AuditableEntity
{
    public Guid OfferId { get; private set; }
    public Guid UserId { get; private set; }
    public CouponCode CouponCode { get; private set; } = null!;
    public DateTimeOffset ClaimedAt { get; private set; }
    public DateTimeOffset ExpiresAt { get; private set; }
    public ClaimStatus Status { get; private set; }

    public Offer? Offer { get; private set; }
    public User? User { get; private set; }

    private readonly List<OfferRedemption> _redemptions = new();
    public IReadOnlyCollection<OfferRedemption> Redemptions => _redemptions.AsReadOnly();

    protected OfferClaim() { }

    public static OfferClaim Create(Guid offerId, Guid userId, CouponCode couponCode, DateTimeOffset expiresAt)
    {
        var claim = new OfferClaim
        {
            OfferId = offerId,
            UserId = userId,
            CouponCode = couponCode,
            ClaimedAt = DateTimeOffset.UtcNow,
            ExpiresAt = expiresAt,
            Status = ClaimStatus.Pending
        };

        claim.AddDomainEvent(new OfferClaimedEvent(offerId, userId, claim.Id));

        return claim;
    }
}
