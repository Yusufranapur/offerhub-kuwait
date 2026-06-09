using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record InviteStaffCommand(Guid VendorId, string Email, string Role) : IRequest<Result>;

public class InviteStaffCommandValidator : AbstractValidator<InviteStaffCommand>
{
    public InviteStaffCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.Role).NotEmpty();
    }
}

public class InviteStaffCommandHandler : IRequestHandler<InviteStaffCommand, Result>
{
    public Task<Result> Handle(InviteStaffCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
