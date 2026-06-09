using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record RedeemOfferCommand(string Code, Guid BranchId) : IRequest<Result<RedemptionResponse>>;

public class RedeemOfferCommandValidator : AbstractValidator<RedeemOfferCommand>
{
    public RedeemOfferCommandValidator()
    {
        RuleFor(v => v.Code).NotEmpty();
        RuleFor(v => v.BranchId).NotEmpty();
    }
}

public class RedeemOfferCommandHandler : IRequestHandler<RedeemOfferCommand, Result<RedemptionResponse>>
{
    public Task<Result<RedemptionResponse>> Handle(RedeemOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<RedemptionResponse>.Success(new RedemptionResponse(Guid.NewGuid(), Guid.NewGuid(), "Mock Offer Title", DateTime.UtcNow, "Success")));
    }
}
