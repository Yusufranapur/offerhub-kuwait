using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record UpdateStaffRoleCommand(Guid StaffId, string Role) : IRequest<Result>;

public class UpdateStaffRoleCommandValidator : AbstractValidator<UpdateStaffRoleCommand>
{
    public UpdateStaffRoleCommandValidator()
    {
        RuleFor(v => v.StaffId).NotEmpty();
        RuleFor(v => v.Role).NotEmpty();
    }
}

public class UpdateStaffRoleCommandHandler : IRequestHandler<UpdateStaffRoleCommand, Result>
{
    public Task<Result> Handle(UpdateStaffRoleCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
