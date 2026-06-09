using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record ApproveVendorCommand(Guid Id) : IRequest<Result>;

public class ApproveVendorCommandValidator : AbstractValidator<ApproveVendorCommand>
{
    public ApproveVendorCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class ApproveVendorCommandHandler : IRequestHandler<ApproveVendorCommand, Result>
{
    public Task<Result> Handle(ApproveVendorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
