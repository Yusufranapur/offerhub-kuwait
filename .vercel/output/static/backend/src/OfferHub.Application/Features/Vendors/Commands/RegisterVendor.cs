using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record RegisterVendorCommand(string Name, string NameAr, string ContactEmail, string ContactPhone) : IRequest<Result<Guid>>;

public class RegisterVendorCommandValidator : AbstractValidator<RegisterVendorCommand>
{
    public RegisterVendorCommandValidator()
    {
        RuleFor(v => v.Name).NotEmpty();
        RuleFor(v => v.ContactEmail).NotEmpty().EmailAddress();
    }
}

public class RegisterVendorCommandHandler : IRequestHandler<RegisterVendorCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(RegisterVendorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
