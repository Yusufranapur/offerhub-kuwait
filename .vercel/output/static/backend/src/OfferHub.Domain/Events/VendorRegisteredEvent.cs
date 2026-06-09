using OfferHub.Domain.Common;

namespace OfferHub.Domain.Events;

public record VendorRegisteredEvent(Guid VendorId) : IDomainEvent;
