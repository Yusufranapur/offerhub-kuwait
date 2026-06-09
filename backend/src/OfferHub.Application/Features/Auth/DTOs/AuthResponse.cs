using System;

namespace OfferHub.Application.Features.Auth.DTOs;

public record AuthResponse(
    string AccessToken,
    string RefreshToken,
    DateTimeOffset ExpiresAt,
    UserDto User);

public record UserDto(
    Guid Id,
    string FullName,
    string Email,
    string? Mobile,
    string? AvatarUrl,
    string? Language,
    string AuthProvider,
    string Status,
    DateTimeOffset CreatedAt);
