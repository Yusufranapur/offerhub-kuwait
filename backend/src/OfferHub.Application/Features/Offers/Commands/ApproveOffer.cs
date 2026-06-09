using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record ApproveOfferCommand(Guid Id) : IRequest<Result>;

public class ApproveOfferCommandValidator : AbstractValidator<ApproveOfferCommand>
{
    public ApproveOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class ApproveOfferCommandHandler : IRequestHandler<ApproveOfferCommand, Result>
{
    public Task<Result> Handle(ApproveOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
