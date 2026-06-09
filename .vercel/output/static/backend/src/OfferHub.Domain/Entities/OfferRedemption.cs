using OfferHub.Domain.Common;
using OfferHub.Domain.Events;

namespace OfferHub.Domain.Entities;

public class OfferRedemption : AuditableEntity
{
    public Guid OfferClaimId { get; private set; }
    public Guid BranchId { get; private set; }
    public Guid RedeemedByStaffId { get; private set; }
    public DateTimeOffset RedeemedAt { get; private set; }

    public OfferClaim? OfferClaim { get; private set; }
    public Branch? Branch { get; private set; }
    public User? RedeemedByStaff { get; private set; }

    protected OfferRedemption() { }

    public static OfferRedemption Create(Guid offerClaimId, Guid branchId, Guid redeemedByStaffId)
    {
        var redemption = new OfferRedemption
        {
            OfferClaimId = offerClaimId,
            BranchId = branchId,
            RedeemedByStaffId = redeemedByStaffId,
            RedeemedAt = DateTimeOffset.UtcNow
        };

        redemption.AddDomainEvent(new OfferRedeemedEvent(Guid.Empty, Guid.Empty, redemption.Id));

        return redemption;
    }
}
