using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record VerifyOtpCommand(string PhoneNumber, string Code) : IRequest<Result<AuthResponse>>;

public class VerifyOtpCommandValidator : AbstractValidator<VerifyOtpCommand>
{
    public VerifyOtpCommandValidator()
    {
        RuleFor(v => v.PhoneNumber).NotEmpty();
        RuleFor(v => v.Code).NotEmpty();
    }
}

public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, Result<AuthResponse>>
{
    public Task<Result<AuthResponse>> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var dto = new UserDto(Guid.NewGuid(), "Test User", "test@test.com", null, null, null, "Local", "Active", DateTimeOffset.UtcNow);
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", DateTimeOffset.UtcNow.AddMinutes(60), dto)));
    }
}
