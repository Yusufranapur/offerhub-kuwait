using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetVendorSubscriptionQuery(Guid VendorId) : IRequest<Result<VendorSubscriptionDto>>;

public class GetVendorSubscriptionQueryHandler : IRequestHandler<GetVendorSubscriptionQuery, Result<VendorSubscriptionDto>>
{
    public Task<Result<VendorSubscriptionDto>> Handle(GetVendorSubscriptionQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorSubscriptionDto>.Success(new VendorSubscriptionDto(Guid.NewGuid(), request.VendorId, Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddMonths(1), true)));
    }
}
