using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record UpdateVendorVerificationCommand(
    Guid VendorId,
    Guid? BusinessCategoryId,
    string? BusinessType,
    string? CivilIdNumber,
    string? CommercialRegistrationNo,
    DateTime? LicenseExpiryDate,
    string? BeneficiaryNameEn,
    string? BeneficiaryNameAr,
    string? BankName,
    string? IbanNumber) : IRequest<Result>;

public class UpdateVendorVerificationCommandValidator : AbstractValidator<UpdateVendorVerificationCommand>
{
    public UpdateVendorVerificationCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
    }
}

public class UpdateVendorVerificationCommandHandler : IRequestHandler<UpdateVendorVerificationCommand, Result>
{
    public Task<Result> Handle(UpdateVendorVerificationCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual repository fetch and update logic.
        return Task.FromResult(Result.Success());
    }
}
