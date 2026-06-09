using OfferHub.Domain.Common;

namespace OfferHub.Domain.Events;

public record OfferClaimedEvent(Guid OfferId, Guid UserId, Guid ClaimId) : IDomainEvent;
