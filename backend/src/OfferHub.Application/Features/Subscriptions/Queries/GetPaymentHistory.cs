using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetPaymentHistoryQuery(Guid VendorId, int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<PaymentHistoryDto>>>;

public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, Result<PaginatedList<PaymentHistoryDto>>>
{
    public Task<Result<PaginatedList<PaymentHistoryDto>>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
    {
        var list = new List<PaymentHistoryDto>();
        return Task.FromResult(Result<PaginatedList<PaymentHistoryDto>>.Success(new PaginatedList<PaymentHistoryDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
