using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record GoogleLoginCommand(string IdToken) : IRequest<Result<AuthResponse>>;

public class GoogleLoginCommandValidator : AbstractValidator<GoogleLoginCommand>
{
    public GoogleLoginCommandValidator()
    {
        RuleFor(v => v.IdToken).NotEmpty();
    }
}

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, Result<AuthResponse>>
{
    public Task<Result<AuthResponse>> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        var dto = new UserDto(Guid.NewGuid(), "Test User", "test@test.com", null, null, null, "Local", "Active", DateTimeOffset.UtcNow);
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", DateTimeOffset.UtcNow.AddMinutes(60), dto)));
    }
}
