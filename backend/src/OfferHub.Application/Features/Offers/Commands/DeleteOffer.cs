using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record DeleteOfferCommand(Guid Id) : IRequest<Result>;

public class DeleteOfferCommandValidator : AbstractValidator<DeleteOfferCommand>
{
    public DeleteOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Result>
{
    public Task<Result> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
