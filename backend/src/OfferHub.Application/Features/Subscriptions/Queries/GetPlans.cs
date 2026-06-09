using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetPlansQuery() : IRequest<Result<List<SubscriptionPlanDto>>>;

public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, Result<List<SubscriptionPlanDto>>>
{
    public Task<Result<List<SubscriptionPlanDto>>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<SubscriptionPlanDto>>.Success(new List<SubscriptionPlanDto>()));
    }
}
