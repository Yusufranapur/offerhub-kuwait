using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;
using OfferHub.Domain.Events;

namespace OfferHub.Domain.Entities;

public class VendorSubscription : AuditableEntity
{
    public Guid VendorId { get; private set; }
    public Guid SubscriptionPlanId { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    public SubscriptionStatus Status { get; private set; }

    public Vendor? Vendor { get; private set; }
    public SubscriptionPlan? SubscriptionPlan { get; private set; }
    public Payment? Payment { get; private set; }

    protected VendorSubscription() { }

    public static VendorSubscription Create(Guid vendorId, Guid subscriptionPlanId, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var subscription = new VendorSubscription
        {
            VendorId = vendorId,
            SubscriptionPlanId = subscriptionPlanId,
            StartDate = startDate,
            EndDate = endDate,
            Status = SubscriptionStatus.PendingPayment
        };

        subscription.AddDomainEvent(new SubscriptionCreatedEvent(vendorId, subscription.Id));

        return subscription;
    }
}
