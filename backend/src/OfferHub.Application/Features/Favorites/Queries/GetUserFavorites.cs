using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;
using OfferHub.Application.Features.Offers;

namespace OfferHub.Application.Features.Favorites.Queries;

public record GetUserFavoritesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class GetUserFavoritesQueryHandler : IRequestHandler<GetUserFavoritesQuery, Result<PaginatedList<OfferDto>>>
{
    public Task<Result<PaginatedList<OfferDto>>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
    {
        var list = new List<OfferDto>();
        return Task.FromResult(Result<PaginatedList<OfferDto>>.Success(new PaginatedList<OfferDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
