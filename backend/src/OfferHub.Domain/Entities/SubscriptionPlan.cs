using OfferHub.Domain.Common;
using OfferHub.Domain.ValueObjects;

namespace OfferHub.Domain.Entities;

public class SubscriptionPlan : AuditableEntity
{
    public string Name { get; private set; } = null!;
    public string NameAr { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string DescriptionAr { get; private set; } = null!;
    public Money Price { get; private set; } = null!;
    public int DurationInDays { get; private set; }
    public int MaxOffers { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<VendorSubscription> _vendorSubscriptions = new();
    public IReadOnlyCollection<VendorSubscription> VendorSubscriptions => _vendorSubscriptions.AsReadOnly();

    protected SubscriptionPlan() { }

    public static SubscriptionPlan Create(string name, string nameAr, string description, string descriptionAr, Money price, int durationInDays, int maxOffers)
    {
        return new SubscriptionPlan
        {
            Name = name,
            NameAr = nameAr,
            Description = description,
            DescriptionAr = descriptionAr,
            Price = price,
            DurationInDays = durationInDays,
            MaxOffers = maxOffers,
            IsActive = true
        };
    }
}
