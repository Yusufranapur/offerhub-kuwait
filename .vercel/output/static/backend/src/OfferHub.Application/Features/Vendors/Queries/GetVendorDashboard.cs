using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorDashboardQuery(Guid VendorId) : IRequest<Result<VendorDashboardDto>>;

public class GetVendorDashboardQueryHandler : IRequestHandler<GetVendorDashboardQuery, Result<VendorDashboardDto>>
{
    public Task<Result<VendorDashboardDto>> Handle(GetVendorDashboardQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorDashboardDto>.Success(new VendorDashboardDto(10, 5, 100, 5000m)));
    }
}
