using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record RemoveStaffCommand(Guid StaffId) : IRequest<Result>;

public class RemoveStaffCommandValidator : AbstractValidator<RemoveStaffCommand>
{
    public RemoveStaffCommandValidator()
    {
        RuleFor(v => v.StaffId).NotEmpty();
    }
}

public class RemoveStaffCommandHandler : IRequestHandler<RemoveStaffCommand, Result>
{
    public Task<Result> Handle(RemoveStaffCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
