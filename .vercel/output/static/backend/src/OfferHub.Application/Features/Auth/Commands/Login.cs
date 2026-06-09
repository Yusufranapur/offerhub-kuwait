using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;
using OfferHub.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfferHub.Application.Features.Auth.DTOs;

namespace OfferHub.Application.Features.Auth.Commands;

public record LoginCommand(string Email, string Password) : IRequest<Result<AuthResponse>>;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.Password).NotEmpty();
    }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly OfferHub.Application.Common.Interfaces.IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IApplicationDbContext dbContext, OfferHub.Application.Common.Interfaces.IPasswordHasher passwordHasher, ITokenService tokenService)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email.Value == request.Email, cancellationToken);

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Result<AuthResponse>.Failure(new[] { "Invalid email or password." });
        }

        var claims = new[] {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email.Value)
        };
        
        var token = _tokenService.GenerateAccessToken(claims);
        var refresh = _tokenService.GenerateRefreshToken();

        var dto = new UserDto(user.Id, $"{user.FirstName} {user.LastName}", user.Email.Value, user.PhoneNumber, null, null, "Local", "Active", user.CreatedAt);
        return Result<AuthResponse>.Success(new AuthResponse(token, refresh, DateTimeOffset.UtcNow.AddMinutes(60), dto));
    }
}
