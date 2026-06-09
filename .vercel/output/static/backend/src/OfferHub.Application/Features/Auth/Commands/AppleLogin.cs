using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record AppleLoginCommand(string IdentityToken) : IRequest<Result<AuthResponse>>;

public class AppleLoginCommandValidator : AbstractValidator<AppleLoginCommand>
{
    public AppleLoginCommandValidator()
    {
        RuleFor(v => v.IdentityToken).NotEmpty();
    }
}

public class AppleLoginCommandHandler : IRequestHandler<AppleLoginCommand, Result<AuthResponse>>
{
    public Task<Result<AuthResponse>> Handle(AppleLoginCommand request, CancellationToken cancellationToken)
    {
        var dto = new UserDto(Guid.NewGuid(), "Test User", "test@test.com", null, null, null, "Local", "Active", DateTimeOffset.UtcNow);
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", DateTimeOffset.UtcNow.AddMinutes(60), dto)));
    }
}
