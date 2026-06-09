$baseDir = "C:\Users\Yusuf\.gemini\antigravity\scratch\offerhub-kuwait\backend\src\OfferHub.Application"

function Create-File($path, $content) {
    $fullPath = Join-Path $baseDir $path
    $dir = Split-Path $fullPath
    if (-not (Test-Path $dir)) {
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
    }
    Set-Content -Path $fullPath -Value $content
}

# --- Auth ---
Create-File "Features\Auth\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Auth;

public record AuthResponse(string AccessToken, string RefreshToken, UserDto User);
public record UserDto(Guid Id, string Email, string FirstName, string LastName, string Role);
"@

Create-File "Features\Auth\Commands\Register.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

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
    public Task<Result<AuthResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", new UserDto(Guid.NewGuid(), request.Email, request.FirstName, request.LastName, "User"))));
    }
}
"@

Create-File "Features\Auth\Commands\Login.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

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
    public Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", new UserDto(Guid.NewGuid(), request.Email, "First", "Last", "User"))));
    }
}
"@

Create-File "Features\Auth\Commands\RefreshToken.cs" @"
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
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("new_token", "new_refresh", new UserDto(Guid.NewGuid(), "email", "First", "Last", "User"))));
    }
}
"@

Create-File "Features\Auth\Commands\GoogleLogin.cs" @"
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
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", new UserDto(Guid.NewGuid(), "email", "First", "Last", "User"))));
    }
}
"@

Create-File "Features\Auth\Commands\AppleLogin.cs" @"
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
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", new UserDto(Guid.NewGuid(), "email", "First", "Last", "User"))));
    }
}
"@

Create-File "Features\Auth\Commands\SendOtp.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record SendOtpCommand(string PhoneNumber) : IRequest<Result>;

public class SendOtpCommandValidator : AbstractValidator<SendOtpCommand>
{
    public SendOtpCommandValidator()
    {
        RuleFor(v => v.PhoneNumber).NotEmpty();
    }
}

public class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, Result>
{
    public Task<Result> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Auth\Commands\VerifyOtp.cs" @"
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
        return Task.FromResult(Result<AuthResponse>.Success(new AuthResponse("token", "refresh", new UserDto(Guid.NewGuid(), "email", "First", "Last", "User"))));
    }
}
"@

Create-File "Features\Auth\Queries\GetCurrentUser.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Queries;

public record GetCurrentUserQuery() : IRequest<Result<UserDto>>;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Result<UserDto>>
{
    public Task<Result<UserDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<UserDto>.Success(new UserDto(Guid.NewGuid(), "email", "First", "Last", "User")));
    }
}
"@

# --- Offers ---
Create-File "Features\Offers\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Offers;

public record OfferDto(Guid Id, string Title, string TitleAr, string Description, string DescriptionAr, decimal DiscountPercentage, DateTime StartDate, DateTime EndDate, Guid VendorId);
public record ClaimResponse(Guid ClaimId, string Code, DateTime ExpiryDate);
public record RedemptionResponse(Guid RedemptionId, DateTime RedeemedAt, decimal AmountSaved);
"@

Create-File "Features\Offers\Commands\CreateOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record CreateOfferCommand(string Title, string TitleAr, string Description, string DescriptionAr, decimal DiscountPercentage, DateTime StartDate, DateTime EndDate, Guid VendorId) : IRequest<Result<Guid>>;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        RuleFor(v => v.Title).NotEmpty();
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.DiscountPercentage).GreaterThan(0);
    }
}

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
"@

Create-File "Features\Offers\Commands\UpdateOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record UpdateOfferCommand(Guid Id, string Title, string TitleAr, string Description, string DescriptionAr, decimal DiscountPercentage, DateTime StartDate, DateTime EndDate) : IRequest<Result>;

public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
{
    public UpdateOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Title).NotEmpty();
        RuleFor(v => v.DiscountPercentage).GreaterThan(0);
    }
}

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Result>
{
    public Task<Result> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Offers\Commands\DeleteOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record DeleteOfferCommand(Guid Id) : IRequest<Result>;

public class DeleteOfferCommandValidator : AbstractValidator<DeleteOfferCommand>
{
    public DeleteOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Result>
{
    public Task<Result> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Offers\Commands\ClaimOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record ClaimOfferCommand(Guid OfferId) : IRequest<Result<ClaimResponse>>;

public class ClaimOfferCommandValidator : AbstractValidator<ClaimOfferCommand>
{
    public ClaimOfferCommandValidator()
    {
        RuleFor(v => v.OfferId).NotEmpty();
    }
}

public class ClaimOfferCommandHandler : IRequestHandler<ClaimOfferCommand, Result<ClaimResponse>>
{
    public Task<Result<ClaimResponse>> Handle(ClaimOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<ClaimResponse>.Success(new ClaimResponse(Guid.NewGuid(), "CODE123", DateTime.UtcNow.AddDays(7))));
    }
}
"@

Create-File "Features\Offers\Commands\RedeemOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record RedeemOfferCommand(string Code, Guid BranchId) : IRequest<Result<RedemptionResponse>>;

public class RedeemOfferCommandValidator : AbstractValidator<RedeemOfferCommand>
{
    public RedeemOfferCommandValidator()
    {
        RuleFor(v => v.Code).NotEmpty();
        RuleFor(v => v.BranchId).NotEmpty();
    }
}

public class RedeemOfferCommandHandler : IRequestHandler<RedeemOfferCommand, Result<RedemptionResponse>>
{
    public Task<Result<RedemptionResponse>> Handle(RedeemOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<RedemptionResponse>.Success(new RedemptionResponse(Guid.NewGuid(), DateTime.UtcNow, 15.5m)));
    }
}
"@

Create-File "Features\Offers\Commands\ApproveOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record ApproveOfferCommand(Guid Id) : IRequest<Result>;

public class ApproveOfferCommandValidator : AbstractValidator<ApproveOfferCommand>
{
    public ApproveOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class ApproveOfferCommandHandler : IRequestHandler<ApproveOfferCommand, Result>
{
    public Task<Result> Handle(ApproveOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Offers\Commands\RejectOffer.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Commands;

public record RejectOfferCommand(Guid Id, string Reason) : IRequest<Result>;

public class RejectOfferCommandValidator : AbstractValidator<RejectOfferCommand>
{
    public RejectOfferCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Reason).NotEmpty();
    }
}

public class RejectOfferCommandHandler : IRequestHandler<RejectOfferCommand, Result>
{
    public Task<Result> Handle(RejectOfferCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Offers\Queries\GetOffers.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetOffersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, Result<PaginatedList<OfferDto>>>
{
    public Task<Result<PaginatedList<OfferDto>>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
    {
        var list = new List<OfferDto>();
        return Task.FromResult(Result<PaginatedList<OfferDto>>.Success(new PaginatedList<OfferDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@

Create-File "Features\Offers\Queries\GetOfferById.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetOfferByIdQuery(Guid Id) : IRequest<Result<OfferDto>>;

public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, Result<OfferDto>>
{
    public Task<Result<OfferDto>> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<OfferDto>.Success(new OfferDto(request.Id, "Title", "TitleAr", "Desc", "DescAr", 10, DateTime.UtcNow, DateTime.UtcNow.AddDays(10), Guid.NewGuid())));
    }
}
"@

Create-File "Features\Offers\Queries\GetFeaturedOffers.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetFeaturedOffersQuery() : IRequest<Result<List<OfferDto>>>;

public class GetFeaturedOffersQueryHandler : IRequestHandler<GetFeaturedOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetFeaturedOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
"@

Create-File "Features\Offers\Queries\GetNearbyOffers.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetNearbyOffersQuery(double Latitude, double Longitude, double RadiusInKm) : IRequest<Result<List<OfferDto>>>;

public class GetNearbyOffersQueryHandler : IRequestHandler<GetNearbyOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetNearbyOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
"@

Create-File "Features\Offers\Queries\GetTrendingOffers.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record GetTrendingOffersQuery() : IRequest<Result<List<OfferDto>>>;

public class GetTrendingOffersQueryHandler : IRequestHandler<GetTrendingOffersQuery, Result<List<OfferDto>>>
{
    public Task<Result<List<OfferDto>>> Handle(GetTrendingOffersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<OfferDto>>.Success(new List<OfferDto>()));
    }
}
"@

Create-File "Features\Offers\Queries\SearchOffers.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Offers.Queries;

public record SearchOffersQuery(string Keyword, Guid? CategoryId, int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class SearchOffersQueryHandler : IRequestHandler<SearchOffersQuery, Result<PaginatedList<OfferDto>>>
{
    public Task<Result<PaginatedList<OfferDto>>> Handle(SearchOffersQuery request, CancellationToken cancellationToken)
    {
        var list = new List<OfferDto>();
        return Task.FromResult(Result<PaginatedList<OfferDto>>.Success(new PaginatedList<OfferDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@
