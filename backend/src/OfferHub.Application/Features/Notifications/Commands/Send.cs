using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Commands;

public record SendNotificationCommand(Guid UserId, string Title, string TitleAr, string Body, string BodyAr) : IRequest<Result>;

public class SendNotificationCommandValidator : AbstractValidator<SendNotificationCommand>
{
    public SendNotificationCommandValidator()
    {
        RuleFor(v => v.UserId).NotEmpty();
        RuleFor(v => v.Title).NotEmpty();
    }
}

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, Result>
{
    public Task<Result> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
