using OfferHub.Domain.Common;

namespace OfferHub.Domain.Events;

public record SubscriptionCreatedEvent(Guid VendorId, Guid SubscriptionId) : IDomainEvent;
