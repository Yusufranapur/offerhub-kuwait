using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record SuspendVendorCommand(Guid Id, string Reason) : IRequest<Result>;

public class SuspendVendorCommandValidator : AbstractValidator<SuspendVendorCommand>
{
    public SuspendVendorCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Reason).NotEmpty();
    }
}

public class SuspendVendorCommandHandler : IRequestHandler<SuspendVendorCommand, Result>
{
    public Task<Result> Handle(SuspendVendorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
