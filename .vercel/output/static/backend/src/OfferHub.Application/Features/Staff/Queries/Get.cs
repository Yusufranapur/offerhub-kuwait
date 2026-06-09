using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Queries;

public record GetStaffQuery(Guid VendorId) : IRequest<Result<List<StaffDto>>>;

public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, Result<List<StaffDto>>>
{
    public Task<Result<List<StaffDto>>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<StaffDto>>.Success(new List<StaffDto>()));
    }
}
