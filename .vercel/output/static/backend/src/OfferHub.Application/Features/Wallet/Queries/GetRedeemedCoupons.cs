using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Wallet.Queries;

public record GetRedeemedCouponsQuery() : IRequest<Result<List<CouponDto>>>;

public class GetRedeemedCouponsQueryHandler : IRequestHandler<GetRedeemedCouponsQuery, Result<List<CouponDto>>>
{
    public Task<Result<List<CouponDto>>> Handle(GetRedeemedCouponsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CouponDto>>.Success(new List<CouponDto>()));
    }
}
