using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record SearchOffersQuery(string Keyword, Guid? CategoryId, int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class SearchOffersQueryHandler : IRequestHandler<SearchOffersQuery, Result<PaginatedList<OfferDto>>>
{
    public Task<Result<PaginatedList<OfferDto>>> Handle(SearchOffersQuery request, CancellationToken cancellationToken)
    {
        var list = new List<OfferDto>();
        return Task.FromResult(Result<PaginatedList<OfferDto>>.Success(new PaginatedList<OfferDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
