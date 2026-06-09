using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Wallet.Queries;

public record GetActiveCouponsQuery() : IRequest<Result<List<CouponDto>>>;

public class GetActiveCouponsQueryHandler : IRequestHandler<GetActiveCouponsQuery, Result<List<CouponDto>>>
{
    public Task<Result<List<CouponDto>>> Handle(GetActiveCouponsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CouponDto>>.Success(new List<CouponDto>()));
    }
}
