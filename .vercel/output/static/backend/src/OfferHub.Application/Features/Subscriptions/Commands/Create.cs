using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Commands;

public record CreateSubscriptionCommand(Guid VendorId, Guid PlanId, string PaymentMethodId) : IRequest<Result<Guid>>;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.PlanId).NotEmpty();
    }
}

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
