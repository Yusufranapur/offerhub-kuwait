using OfferHub.Domain.Common;

namespace OfferHub.Domain.Events;

public record OfferRedeemedEvent(Guid OfferId, Guid UserId, Guid RedemptionId) : IDomainEvent;
