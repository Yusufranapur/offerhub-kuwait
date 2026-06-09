using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetFeaturedOffersQuery() : IRequest<Result<List<OfferDto>>>;

public class GetFeaturedOffersQueryHandler : IRequestHandler<GetFeaturedOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetFeaturedOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
