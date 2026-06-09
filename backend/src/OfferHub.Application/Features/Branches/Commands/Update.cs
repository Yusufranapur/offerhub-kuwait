using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record UpdateBranchCommand(Guid Id, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber) : IRequest<Result>;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Result>
{
    public Task<Result> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
