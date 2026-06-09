using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Queries;

public record GetBranchesQuery(Guid VendorId) : IRequest<Result<List<BranchDto>>>;

public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, Result<List<BranchDto>>>
{
    public Task<Result<List<BranchDto>>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<BranchDto>>.Success(new List<BranchDto>()));
    }
}
