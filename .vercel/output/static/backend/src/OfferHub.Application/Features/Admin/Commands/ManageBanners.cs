using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Commands;

public record ManageBannersCommand(string Action, Guid? BannerId, string ImageUrl, string LinkUrl) : IRequest<Result>;

public class ManageBannersCommandValidator : AbstractValidator<ManageBannersCommand>
{
    public ManageBannersCommandValidator()
    {
        RuleFor(v => v.Action).NotEmpty();
    }
}

public class ManageBannersCommandHandler : IRequestHandler<ManageBannersCommand, Result>
{
    public Task<Result> Handle(ManageBannersCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
