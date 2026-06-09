using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record CreateBranchCommand(Guid VendorId, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber) : IRequest<Result<Guid>>;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
