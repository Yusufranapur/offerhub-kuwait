using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class OfferImage : AuditableEntity
{
    public Guid OfferId { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    public bool IsPrimary { get; private set; }
    public int DisplayOrder { get; private set; }

    public Offer? Offer { get; private set; }

    protected OfferImage() { }

    public static OfferImage Create(Guid offerId, string imageUrl, bool isPrimary, int displayOrder)
    {
        return new OfferImage
        {
            OfferId = offerId,
            ImageUrl = imageUrl,
            IsPrimary = isPrimary,
            DisplayOrder = displayOrder
        };
    }
}
