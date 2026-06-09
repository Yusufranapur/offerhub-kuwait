using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<VendorDto>>>;

public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, Result<PaginatedList<VendorDto>>>
{
    public Task<Result<PaginatedList<VendorDto>>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
    {
        var list = new List<VendorDto>();
        return Task.FromResult(Result<PaginatedList<VendorDto>>.Success(new PaginatedList<VendorDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
