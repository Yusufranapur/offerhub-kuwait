using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetTrendingOffersQuery() : IRequest<Result<List<OfferDto>>>;

public class GetTrendingOffersQueryHandler : IRequestHandler<GetTrendingOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetTrendingOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
