using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Interfaces;
using OfferHub.Application.Common.Models;
using OfferHub.Domain.Entities;
using OfferHub.Domain.Enums;

namespace OfferHub.Application.Features.Offers.Commands;

public record CreateOfferCommand(
    string Title, 
    string TitleAr, 
    string Description, 
    string DescriptionAr, 
    DiscountType DiscountType,
    decimal DiscountValue, 
    DateTimeOffset StartDate, 
    DateTimeOffset EndDate, 
    int MaxClaims,
    Guid VendorId,
    Guid CategoryId) : IRequest<Result<Guid>>;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        RuleFor(v => v.Title).NotEmpty();
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.DiscountValue).GreaterThan(0);
        RuleFor(v => v.EndDate).GreaterThan(v => v.StartDate);
    }
}

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateOfferCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = Offer.Create(
            request.VendorId,
            request.CategoryId,
            request.Title,
            request.TitleAr ?? request.Title,
            request.Description ?? "",
            request.DescriptionAr ?? "",
            request.DiscountType,
            request.DiscountValue,
            request.StartDate,
            request.EndDate,
            request.MaxClaims > 0 ? request.MaxClaims : 1000
        );

        _context.Offers.Add(offer);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(offer.Id);
    }
}
