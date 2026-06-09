using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class Favorite : AuditableEntity
{
    public Guid UserId { get; private set; }
    public Guid OfferId { get; private set; }

    public User? User { get; private set; }
    public Offer? Offer { get; private set; }

    protected Favorite() { }

    public static Favorite Create(Guid userId, Guid offerId)
    {
        return new Favorite
        {
            UserId = userId,
            OfferId = offerId
        };
    }
}
