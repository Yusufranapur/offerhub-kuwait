using OfferHub.Domain.Common;

namespace OfferHub.Domain.Events;

public record VendorApprovedEvent(Guid VendorId) : IDomainEvent;
