using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorByIdQuery(Guid Id) : IRequest<Result<VendorDto>>;

public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Result<VendorDto>>
{
    public Task<Result<VendorDto>> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorDto>.Success(new VendorDto(request.Id, "Name", "NameAr", "Desc", "DescAr", "Logo", "email", "phone")));
    }
}
