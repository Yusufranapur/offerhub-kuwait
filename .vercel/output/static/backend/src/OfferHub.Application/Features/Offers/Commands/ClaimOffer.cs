using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record ClaimOfferCommand(Guid OfferId) : IRequest<Result<ClaimResponse>>;

public class ClaimOfferCommandValidator : AbstractValidator<ClaimOfferCommand>
{
    public ClaimOfferCommandValidator()
    {
        RuleFor(v => v.OfferId).NotEmpty();
    }
}

public class ClaimOfferCommandHandler : IRequestHandler<ClaimOfferCommand, Result<ClaimResponse>>
{
    public Task<Result<ClaimResponse>> Handle(ClaimOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<ClaimResponse>.Success(new ClaimResponse(Guid.NewGuid(), "CODE123", "QRDATA", DateTime.UtcNow.AddDays(1))));
    }
}
