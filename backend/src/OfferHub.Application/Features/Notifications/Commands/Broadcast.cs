using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Commands;

public record BroadcastNotificationCommand(string Title, string TitleAr, string Body, string BodyAr) : IRequest<Result>;

public class BroadcastNotificationCommandValidator : AbstractValidator<BroadcastNotificationCommand>
{
    public BroadcastNotificationCommandValidator()
    {
        RuleFor(v => v.Title).NotEmpty();
    }
}

public class BroadcastNotificationCommandHandler : IRequestHandler<BroadcastNotificationCommand, Result>
{
    public Task<Result> Handle(BroadcastNotificationCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
