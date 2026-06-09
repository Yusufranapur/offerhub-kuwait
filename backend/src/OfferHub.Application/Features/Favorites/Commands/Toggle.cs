using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Favorites.Commands;

public record ToggleFavoriteCommand(Guid OfferId) : IRequest<Result>;

public class ToggleFavoriteCommandValidator : AbstractValidator<ToggleFavoriteCommand>
{
    public ToggleFavoriteCommandValidator()
    {
        RuleFor(v => v.OfferId).NotEmpty();
    }
}

public class ToggleFavoriteCommandHandler : IRequestHandler<ToggleFavoriteCommand, Result>
{
    public Task<Result> Handle(ToggleFavoriteCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
