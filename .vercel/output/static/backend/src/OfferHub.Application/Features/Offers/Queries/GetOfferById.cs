using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetOfferByIdQuery(Guid Id) : IRequest<Result<OfferDto>>;

public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, Result<OfferDto>>
{
    public Task<Result<OfferDto>> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = new OfferDto(request.Id, Guid.NewGuid(), null, null, null, Guid.NewGuid(), null, null, "Mock Offer", "Mock Offer", null, null, "Percentage", 50, null, null, null, DateTime.UtcNow, DateTime.UtcNow.AddDays(10), 100, 0, false, "Active", DateTime.UtcNow);
        return Task.FromResult(Result<OfferDto>.Success(dto));
    }
}
