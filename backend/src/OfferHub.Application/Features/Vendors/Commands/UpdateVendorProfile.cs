using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record UpdateVendorProfileCommand(Guid Id, string Name, string NameAr, string Description, string DescriptionAr, string LogoUrl, string ContactPhone) : IRequest<Result>;

public class UpdateVendorProfileCommandValidator : AbstractValidator<UpdateVendorProfileCommand>
{
    public UpdateVendorProfileCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateVendorProfileCommandHandler : IRequestHandler<UpdateVendorProfileCommand, Result>
{
    public Task<Result> Handle(UpdateVendorProfileCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
