using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetOffersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, Result<PaginatedList<OfferDto>>>
{
    private readonly OfferHub.Application.Common.Interfaces.IApplicationDbContext _context;

    public GetOffersQueryHandler(OfferHub.Application.Common.Interfaces.IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PaginatedList<OfferDto>>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
    {
        var query = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AsNoTracking(_context.Offers);
        
        var totalCount = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.CountAsync(query, cancellationToken);
        
        var items = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
            System.Linq.Queryable.Skip(System.Linq.Queryable.OrderByDescending(query, o => o.CreatedAt), (request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(o => new OfferDto(
                o.Id,
                o.VendorId,
                null,
                null,
                null,
                o.CategoryId,
                null,
                null,
                o.Title,
                o.TitleAr,
                o.Description,
                o.DescriptionAr,
                o.DiscountType.ToString(),
                o.DiscountValue,
                null,
                null,
                null,
                o.StartDate.DateTime,
                o.EndDate.DateTime,
                o.MaxClaims,
                o.CurrentClaims,
                false,
                o.Status.ToString(),
                o.CreatedAt.DateTime
            )), cancellationToken);

        var paginatedList = new PaginatedList<OfferDto>(items, totalCount, request.PageNumber, request.PageSize);
        return Result<PaginatedList<OfferDto>>.Success(paginatedList);
    }
}
