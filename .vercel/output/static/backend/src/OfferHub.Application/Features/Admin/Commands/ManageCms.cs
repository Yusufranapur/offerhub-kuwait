using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Commands;

public record ManageCmsCommand(string Page, string Content, string ContentAr) : IRequest<Result>;

public class ManageCmsCommandValidator : AbstractValidator<ManageCmsCommand>
{
    public ManageCmsCommandValidator()
    {
        RuleFor(v => v.Page).NotEmpty();
    }
}

public class ManageCmsCommandHandler : IRequestHandler<ManageCmsCommand, Result>
{
    public Task<Result> Handle(ManageCmsCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
