using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using OfferHub.Application.Common.Models;
using OfferHub.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfferHub.Domain.Entities;
using OfferHub.Domain.ValueObjects;
using System.Linq;
using OfferHub.Application.Features.Auth.DTOs;

namespace OfferHub.Application.Features.Auth.Commands;

public record RegisterCommand(string Email, string Password, string FirstName, string LastName) : IRequest<Result<AuthResponse>>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.Password).NotEmpty().MinimumLength(6);
        RuleFor(v => v.FirstName).NotEmpty();
        RuleFor(v => v.LastName).NotEmpty();
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly OfferHub.Application.Common.Interfaces.IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(IApplicationDbContext dbContext, OfferHub.Application.Common.Interfaces.IPasswordHasher passwordHasher, ITokenService tokenService)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<Result<AuthResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if email exists
        if (await _dbContext.Users.AnyAsync(u => u.Email.Value == request.Email, cancellationToken))
        {
            return Result<AuthResponse>.Failure(new[] { "Email already exists." });
        }

        var user = User.Create(
            request.FirstName, 
            request.LastName, 
            Email.Create(request.Email), 
            _passwordHasher.HashPassword(request.Password), 
            null);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

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
