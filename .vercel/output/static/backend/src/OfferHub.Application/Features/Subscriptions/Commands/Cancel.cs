using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Commands;

public record CancelSubscriptionCommand(Guid SubscriptionId) : IRequest<Result>;

public class CancelSubscriptionCommandValidator : AbstractValidator<CancelSubscriptionCommand>
{
    public CancelSubscriptionCommandValidator()
    {
        RuleFor(v => v.SubscriptionId).NotEmpty();
    }
}

public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, Result>
{
    public Task<Result> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
