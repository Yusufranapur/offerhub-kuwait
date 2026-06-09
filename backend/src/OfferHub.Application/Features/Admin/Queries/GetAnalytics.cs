using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Queries;

public record GetAnalyticsQuery() : IRequest<Result<AnalyticsDto>>;

public class GetAnalyticsQueryHandler : IRequestHandler<GetAnalyticsQuery, Result<AnalyticsDto>>
{
    public Task<Result<AnalyticsDto>> Handle(GetAnalyticsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<AnalyticsDto>.Success(new AnalyticsDto(100, 500, 2500)));
    }
}
