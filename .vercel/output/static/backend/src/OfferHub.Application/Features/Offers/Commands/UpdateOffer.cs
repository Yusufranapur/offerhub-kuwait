using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record UpdateOfferCommand(Guid Id, string Title, string TitleAr, string Description, string DescriptionAr, decimal DiscountPercentage, DateTime StartDate, DateTime EndDate) : IRequest<Result>;

public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
{
    public UpdateOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Title).NotEmpty();
        RuleFor(v => v.DiscountPercentage).GreaterThan(0);
    }
}

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Result>
{
    public Task<Result> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
