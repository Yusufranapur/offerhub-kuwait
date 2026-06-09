using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<Result<AuthResponse>>;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(v => v.Token).NotEmpty();
        RuleFor(v => v.RefreshToken).NotEmpty();
    }
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
{
    public Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var dto = new UserDto(Guid.NewGuid(), "Test User", "test@test.com", null, null, null, "Local", "Active", DateTimeOffset.UtcNow);
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", DateTimeOffset.UtcNow.AddMinutes(60), dto)));
    }
}
