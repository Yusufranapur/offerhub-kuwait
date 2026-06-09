using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;
using OfferHub.Domain.ValueObjects;

namespace OfferHub.Domain.Entities;

public class Payment : AuditableEntity
{
    public Guid VendorSubscriptionId { get; private set; }
    public Money Amount { get; private set; } = null!;
    public string TransactionId { get; private set; } = null!;
    public PaymentStatus Status { get; private set; }
    public string? PaymentMethod { get; private set; }

    public VendorSubscription? VendorSubscription { get; private set; }

    protected Payment() { }

    public static Payment Create(Guid vendorSubscriptionId, Money amount, string transactionId, string? paymentMethod)
    {
        return new Payment
        {
            VendorSubscriptionId = vendorSubscriptionId,
            Amount = amount,
            TransactionId = transactionId,
            PaymentMethod = paymentMethod,
            Status = PaymentStatus.Pending
        };
    }
}
