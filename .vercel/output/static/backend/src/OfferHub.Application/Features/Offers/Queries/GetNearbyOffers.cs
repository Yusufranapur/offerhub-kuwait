using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetNearbyOffersQuery(double Latitude, double Longitude, double RadiusInKm) : IRequest<Result<List<OfferDto>>>;

public class GetNearbyOffersQueryHandler : IRequestHandler<GetNearbyOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetNearbyOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
