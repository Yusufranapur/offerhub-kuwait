using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Queries;

public record GetNearbyBranchesQuery(double Latitude, double Longitude, double RadiusInKm) : IRequest<Result<List<BranchDto>>>;

public class GetNearbyBranchesQueryHandler : IRequestHandler<GetNearbyBranchesQuery, Result<List<BranchDto>>>
{
    public Task<Result<List<BranchDto>>> Handle(GetNearbyBranchesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<BranchDto>>.Success(new List<BranchDto>()));
    }
}
