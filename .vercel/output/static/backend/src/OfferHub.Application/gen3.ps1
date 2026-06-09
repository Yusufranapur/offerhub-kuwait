$baseDir = "C:\Users\Yusuf\.gemini\antigravity\scratch\offerhub-kuwait\backend\src\OfferHub.Application"

function Create-File($path, $content) {
    $fullPath = Join-Path $baseDir $path
    $dir = Split-Path $fullPath
    if (-not (Test-Path $dir)) {
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
    }
    Set-Content -Path $fullPath -Value $content
}

# --- Favorites ---
Create-File "Features\Favorites\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Favorites;

public record FavoriteDto(Guid Id, Guid UserId, Guid OfferId);
"@

Create-File "Features\Favorites\Commands\Toggle.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Favorites.Commands;

public record ToggleFavoriteCommand(Guid OfferId) : IRequest<Result>;

public class ToggleFavoriteCommandValidator : AbstractValidator<ToggleFavoriteCommand>
{
    public ToggleFavoriteCommandValidator()
    {
        RuleFor(v => v.OfferId).NotEmpty();
    }
}

public class ToggleFavoriteCommandHandler : IRequestHandler<ToggleFavoriteCommand, Result>
{
    public Task<Result> Handle(ToggleFavoriteCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Favorites\Queries\GetUserFavorites.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;
using OfferHub.Application.Features.Offers;

namespace OfferHub.Application.Features.Favorites.Queries;

public record GetUserFavoritesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<OfferDto>>>;

public class GetUserFavoritesQueryHandler : IRequestHandler<GetUserFavoritesQuery, Result<PaginatedList<OfferDto>>>
{
    public Task<Result<PaginatedList<OfferDto>>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
    {
        var list = new List<OfferDto>();
        return Task.FromResult(Result<PaginatedList<OfferDto>>.Success(new PaginatedList<OfferDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@

# --- Wallet ---
Create-File "Features\Wallet\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Wallet;

public record CouponDto(Guid Id, Guid OfferId, string Code, DateTime ExpiryDate, bool IsRedeemed, DateTime? RedeemedAt);
"@

Create-File "Features\Wallet\Queries\GetActiveCoupons.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Wallet.Queries;

public record GetActiveCouponsQuery() : IRequest<Result<List<CouponDto>>>;

public class GetActiveCouponsQueryHandler : IRequestHandler<GetActiveCouponsQuery, Result<List<CouponDto>>>
{
    public Task<Result<List<CouponDto>>> Handle(GetActiveCouponsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CouponDto>>.Success(new List<CouponDto>()));
    }
}
"@

Create-File "Features\Wallet\Queries\GetRedeemedCoupons.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Wallet.Queries;

public record GetRedeemedCouponsQuery() : IRequest<Result<List<CouponDto>>>;

public class GetRedeemedCouponsQueryHandler : IRequestHandler<GetRedeemedCouponsQuery, Result<List<CouponDto>>>
{
    public Task<Result<List<CouponDto>>> Handle(GetRedeemedCouponsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CouponDto>>.Success(new List<CouponDto>()));
    }
}
"@

Create-File "Features\Wallet\Queries\GetExpiredCoupons.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Wallet.Queries;

public record GetExpiredCouponsQuery() : IRequest<Result<List<CouponDto>>>;

public class GetExpiredCouponsQueryHandler : IRequestHandler<GetExpiredCouponsQuery, Result<List<CouponDto>>>
{
    public Task<Result<List<CouponDto>>> Handle(GetExpiredCouponsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CouponDto>>.Success(new List<CouponDto>()));
    }
}
"@

# --- Subscriptions ---
Create-File "Features\Subscriptions\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Subscriptions;

public record SubscriptionPlanDto(Guid Id, string Name, string NameAr, decimal Price, int DurationInDays, int MaxOffers);
public record VendorSubscriptionDto(Guid Id, Guid VendorId, Guid PlanId, DateTime StartDate, DateTime EndDate, bool IsActive);
public record PaymentHistoryDto(Guid Id, Guid VendorId, decimal Amount, string Currency, DateTime PaymentDate, string Status);
"@

Create-File "Features\Subscriptions\Commands\Create.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Commands;

public record CreateSubscriptionCommand(Guid VendorId, Guid PlanId, string PaymentMethodId) : IRequest<Result<Guid>>;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.PlanId).NotEmpty();
    }
}

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
"@

Create-File "Features\Subscriptions\Commands\Cancel.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Commands;

public record CancelSubscriptionCommand(Guid SubscriptionId) : IRequest<Result>;

public class CancelSubscriptionCommandValidator : AbstractValidator<CancelSubscriptionCommand>
{
    public CancelSubscriptionCommandValidator()
    {
        RuleFor(v => v.SubscriptionId).NotEmpty();
    }
}

public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, Result>
{
    public Task<Result> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Subscriptions\Queries\GetPlans.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetPlansQuery() : IRequest<Result<List<SubscriptionPlanDto>>>;

public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, Result<List<SubscriptionPlanDto>>>
{
    public Task<Result<List<SubscriptionPlanDto>>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<SubscriptionPlanDto>>.Success(new List<SubscriptionPlanDto>()));
    }
}
"@

Create-File "Features\Subscriptions\Queries\GetVendorSubscription.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetVendorSubscriptionQuery(Guid VendorId) : IRequest<Result<VendorSubscriptionDto>>;

public class GetVendorSubscriptionQueryHandler : IRequestHandler<GetVendorSubscriptionQuery, Result<VendorSubscriptionDto>>
{
    public Task<Result<VendorSubscriptionDto>> Handle(GetVendorSubscriptionQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorSubscriptionDto>.Success(new VendorSubscriptionDto(Guid.NewGuid(), request.VendorId, Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddMonths(1), true)));
    }
}
"@

Create-File "Features\Subscriptions\Queries\GetPaymentHistory.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Subscriptions.Queries;

public record GetPaymentHistoryQuery(Guid VendorId, int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<PaymentHistoryDto>>>;

public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, Result<PaginatedList<PaymentHistoryDto>>>
{
    public Task<Result<PaginatedList<PaymentHistoryDto>>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
    {
        var list = new List<PaymentHistoryDto>();
        return Task.FromResult(Result<PaginatedList<PaymentHistoryDto>>.Success(new PaginatedList<PaymentHistoryDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@

# --- Notifications ---
Create-File "Features\Notifications\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Notifications;

public record NotificationDto(Guid Id, string Title, string TitleAr, string Body, string BodyAr, bool IsRead, DateTime CreatedAt);
"@

Create-File "Features\Notifications\Commands\Send.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Commands;

public record SendNotificationCommand(Guid UserId, string Title, string TitleAr, string Body, string BodyAr) : IRequest<Result>;

public class SendNotificationCommandValidator : AbstractValidator<SendNotificationCommand>
{
    public SendNotificationCommandValidator()
    {
        RuleFor(v => v.UserId).NotEmpty();
        RuleFor(v => v.Title).NotEmpty();
    }
}

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, Result>
{
    public Task<Result> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Notifications\Commands\Broadcast.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Commands;

public record BroadcastNotificationCommand(string Title, string TitleAr, string Body, string BodyAr) : IRequest<Result>;

public class BroadcastNotificationCommandValidator : AbstractValidator<BroadcastNotificationCommand>
{
    public BroadcastNotificationCommandValidator()
    {
        RuleFor(v => v.Title).NotEmpty();
    }
}

public class BroadcastNotificationCommandHandler : IRequestHandler<BroadcastNotificationCommand, Result>
{
    public Task<Result> Handle(BroadcastNotificationCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Notifications\Commands\MarkAsRead.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Commands;

public record MarkNotificationAsReadCommand(Guid NotificationId) : IRequest<Result>;

public class MarkNotificationAsReadCommandValidator : AbstractValidator<MarkNotificationAsReadCommand>
{
    public MarkNotificationAsReadCommandValidator()
    {
        RuleFor(v => v.NotificationId).NotEmpty();
    }
}

public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommand, Result>
{
    public Task<Result> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Notifications\Queries\Get.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Queries;

public record GetNotificationsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<NotificationDto>>>;

public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, Result<PaginatedList<NotificationDto>>>
{
    public Task<Result<PaginatedList<NotificationDto>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        var list = new List<NotificationDto>();
        return Task.FromResult(Result<PaginatedList<NotificationDto>>.Success(new PaginatedList<NotificationDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@

# --- Admin ---
Create-File "Features\Admin\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Admin;

public record DashboardStatsDto(int TotalUsers, int TotalVendors, int ActiveOffers, decimal TotalRevenue);
public record AnalyticsDto(int DailyActiveUsers, int WeeklyActiveUsers, int TotalRedemptions);
"@

Create-File "Features\Admin\Queries\GetDashboardStats.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Queries;

public record GetDashboardStatsQuery() : IRequest<Result<DashboardStatsDto>>;

public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, Result<DashboardStatsDto>>
{
    public Task<Result<DashboardStatsDto>> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<DashboardStatsDto>.Success(new DashboardStatsDto(1000, 50, 200, 15000m)));
    }
}
"@

Create-File "Features\Admin\Queries\GetAnalytics.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Queries;

public record GetAnalyticsQuery() : IRequest<Result<AnalyticsDto>>;

public class GetAnalyticsQueryHandler : IRequestHandler<GetAnalyticsQuery, Result<AnalyticsDto>>
{
    public Task<Result<AnalyticsDto>> Handle(GetAnalyticsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<AnalyticsDto>.Success(new AnalyticsDto(100, 500, 2500)));
    }
}
"@

Create-File "Features\Admin\Commands\ManageBanners.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Commands;

public record ManageBannersCommand(string Action, Guid? BannerId, string ImageUrl, string LinkUrl) : IRequest<Result>;

public class ManageBannersCommandValidator : AbstractValidator<ManageBannersCommand>
{
    public ManageBannersCommandValidator()
    {
        RuleFor(v => v.Action).NotEmpty();
    }
}

public class ManageBannersCommandHandler : IRequestHandler<ManageBannersCommand, Result>
{
    public Task<Result> Handle(ManageBannersCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Admin\Commands\ManageCms.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Admin.Commands;

public record ManageCmsCommand(string Page, string Content, string ContentAr) : IRequest<Result>;

public class ManageCmsCommandValidator : AbstractValidator<ManageCmsCommand>
{
    public ManageCmsCommandValidator()
    {
        RuleFor(v => v.Page).NotEmpty();
    }
}

public class ManageCmsCommandHandler : IRequestHandler<ManageCmsCommand, Result>
{
    public Task<Result> Handle(ManageCmsCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@
