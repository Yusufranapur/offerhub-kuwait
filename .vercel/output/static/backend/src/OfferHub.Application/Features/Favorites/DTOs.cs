using System;
namespace OfferHub.Application.Features.Favorites;

public record FavoriteDto(Guid Id, Guid UserId, Guid OfferId);
