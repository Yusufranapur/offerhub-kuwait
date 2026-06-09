using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class OfferBranch : AuditableEntity
{
    public Guid OfferId { get; private set; }
    public Guid BranchId { get; private set; }

    public Offer? Offer { get; private set; }
    public Branch? Branch { get; private set; }

    protected OfferBranch() { }

    public static OfferBranch Create(Guid offerId, Guid branchId)
    {
        return new OfferBranch
        {
            OfferId = offerId,
            BranchId = branchId
        };
    }
}
