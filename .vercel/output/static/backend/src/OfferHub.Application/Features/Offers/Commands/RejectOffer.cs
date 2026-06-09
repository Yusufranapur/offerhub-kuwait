using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record RejectOfferCommand(Guid Id, string Reason) : IRequest<Result>;

public class RejectOfferCommandValidator : AbstractValidator<RejectOfferCommand>
{
    public RejectOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Reason).NotEmpty();
    }
}

public class RejectOfferCommandHandler : IRequestHandler<RejectOfferCommand, Result>
{
    public Task<Result> Handle(RejectOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
