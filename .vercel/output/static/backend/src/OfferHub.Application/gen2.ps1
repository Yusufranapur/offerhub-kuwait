$baseDir = "C:\Users\Yusuf\.gemini\antigravity\scratch\offerhub-kuwait\backend\src\OfferHub.Application"

function Create-File($path, $content) {
    $fullPath = Join-Path $baseDir $path
    $dir = Split-Path $fullPath
    if (-not (Test-Path $dir)) {
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
    }
    Set-Content -Path $fullPath -Value $content
}

# --- Vendors ---
Create-File "Features\Vendors\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Vendors;

public record VendorDto(Guid Id, string Name, string NameAr, string Description, string DescriptionAr, string LogoUrl, string ContactEmail, string ContactPhone);
public record VendorDashboardDto(int TotalOffers, int ActiveOffers, int TotalRedemptions, decimal TotalRevenue);
"@

Create-File "Features\Vendors\Commands\RegisterVendor.cs" @"
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
"@

Create-File "Features\Vendors\Commands\UpdateVendorProfile.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record UpdateVendorProfileCommand(Guid Id, string Name, string NameAr, string Description, string DescriptionAr, string LogoUrl, string ContactPhone) : IRequest<Result>;

public class UpdateVendorProfileCommandValidator : AbstractValidator<UpdateVendorProfileCommand>
{
    public UpdateVendorProfileCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateVendorProfileCommandHandler : IRequestHandler<UpdateVendorProfileCommand, Result>
{
    public Task<Result> Handle(UpdateVendorProfileCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Vendors\Commands\ApproveVendor.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record ApproveVendorCommand(Guid Id) : IRequest<Result>;

public class ApproveVendorCommandValidator : AbstractValidator<ApproveVendorCommand>
{
    public ApproveVendorCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class ApproveVendorCommandHandler : IRequestHandler<ApproveVendorCommand, Result>
{
    public Task<Result> Handle(ApproveVendorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Vendors\Commands\SuspendVendor.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Commands;

public record SuspendVendorCommand(Guid Id, string Reason) : IRequest<Result>;

public class SuspendVendorCommandValidator : AbstractValidator<SuspendVendorCommand>
{
    public SuspendVendorCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Reason).NotEmpty();
    }
}

public class SuspendVendorCommandHandler : IRequestHandler<SuspendVendorCommand, Result>
{
    public Task<Result> Handle(SuspendVendorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Vendors\Queries\GetVendors.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<VendorDto>>>;

public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, Result<PaginatedList<VendorDto>>>
{
    public Task<Result<PaginatedList<VendorDto>>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
    {
        var list = new List<VendorDto>();
        return Task.FromResult(Result<PaginatedList<VendorDto>>.Success(new PaginatedList<VendorDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
"@

Create-File "Features\Vendors\Queries\GetVendorById.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorByIdQuery(Guid Id) : IRequest<Result<VendorDto>>;

public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Result<VendorDto>>
{
    public Task<Result<VendorDto>> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorDto>.Success(new VendorDto(request.Id, "Name", "NameAr", "Desc", "DescAr", "Logo", "email", "phone")));
    }
}
"@

Create-File "Features\Vendors\Queries\GetVendorDashboard.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Vendors.Queries;

public record GetVendorDashboardQuery(Guid VendorId) : IRequest<Result<VendorDashboardDto>>;

public class GetVendorDashboardQueryHandler : IRequestHandler<GetVendorDashboardQuery, Result<VendorDashboardDto>>
{
    public Task<Result<VendorDashboardDto>> Handle(GetVendorDashboardQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<VendorDashboardDto>.Success(new VendorDashboardDto(10, 5, 100, 5000m)));
    }
}
"@

# --- Categories ---
Create-File "Features\Categories\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Categories;

public record CategoryDto(Guid Id, string Name, string NameAr, string IconUrl);
"@

Create-File "Features\Categories\Commands\Create.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string Name, string NameAr, string IconUrl) : IRequest<Result<Guid>>;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
"@

Create-File "Features\Categories\Commands\Update.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(Guid Id, string Name, string NameAr, string IconUrl) : IRequest<Result>;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    public Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Categories\Commands\Delete.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Categories.Commands;

public record DeleteCategoryCommand(Guid Id) : IRequest<Result>;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
{
    public Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Categories\Queries\Get.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Categories.Queries;

public record GetCategoriesQuery() : IRequest<Result<List<CategoryDto>>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<List<CategoryDto>>>
{
    public Task<Result<List<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<CategoryDto>>.Success(new List<CategoryDto>()));
    }
}
"@

# --- Branches ---
Create-File "Features\Branches\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Branches;

public record BranchDto(Guid Id, Guid VendorId, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber);
"@

Create-File "Features\Branches\Commands\Create.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record CreateBranchCommand(Guid VendorId, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber) : IRequest<Result<Guid>>;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<Guid>.Success(Guid.NewGuid()));
    }
}
"@

Create-File "Features\Branches\Commands\Update.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record UpdateBranchCommand(Guid Id, string Name, string NameAr, string Address, string AddressAr, double Latitude, double Longitude, string PhoneNumber) : IRequest<Result>;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Result>
{
    public Task<Result> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Branches\Commands\Delete.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record DeleteBranchCommand(Guid Id) : IRequest<Result>;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Result>
{
    public Task<Result> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Branches\Queries\Get.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Queries;

public record GetBranchesQuery(Guid VendorId) : IRequest<Result<List<BranchDto>>>;

public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, Result<List<BranchDto>>>
{
    public Task<Result<List<BranchDto>>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<BranchDto>>.Success(new List<BranchDto>()));
    }
}
"@

Create-File "Features\Branches\Queries\GetNearby.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Queries;

public record GetNearbyBranchesQuery(double Latitude, double Longitude, double RadiusInKm) : IRequest<Result<List<BranchDto>>>;

public class GetNearbyBranchesQueryHandler : IRequestHandler<GetNearbyBranchesQuery, Result<List<BranchDto>>>
{
    public Task<Result<List<BranchDto>>> Handle(GetNearbyBranchesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<BranchDto>>.Success(new List<BranchDto>()));
    }
}
"@

# --- Staff ---
Create-File "Features\Staff\DTOs.cs" @"
using System;
namespace OfferHub.Application.Features.Staff;

public record StaffDto(Guid Id, Guid VendorId, Guid UserId, string Role);
"@

Create-File "Features\Staff\Commands\Invite.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record InviteStaffCommand(Guid VendorId, string Email, string Role) : IRequest<Result>;

public class InviteStaffCommandValidator : AbstractValidator<InviteStaffCommand>
{
    public InviteStaffCommandValidator()
    {
        RuleFor(v => v.VendorId).NotEmpty();
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.Role).NotEmpty();
    }
}

public class InviteStaffCommandHandler : IRequestHandler<InviteStaffCommand, Result>
{
    public Task<Result> Handle(InviteStaffCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Staff\Commands\UpdateRole.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record UpdateStaffRoleCommand(Guid StaffId, string Role) : IRequest<Result>;

public class UpdateStaffRoleCommandValidator : AbstractValidator<UpdateStaffRoleCommand>
{
    public UpdateStaffRoleCommandValidator()
    {
        RuleFor(v => v.StaffId).NotEmpty();
        RuleFor(v => v.Role).NotEmpty();
    }
}

public class UpdateStaffRoleCommandHandler : IRequestHandler<UpdateStaffRoleCommand, Result>
{
    public Task<Result> Handle(UpdateStaffRoleCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Staff\Commands\Remove.cs" @"
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Commands;

public record RemoveStaffCommand(Guid StaffId) : IRequest<Result>;

public class RemoveStaffCommandValidator : AbstractValidator<RemoveStaffCommand>
{
    public RemoveStaffCommandValidator()
    {
        RuleFor(v => v.StaffId).NotEmpty();
    }
}

public class RemoveStaffCommandHandler : IRequestHandler<RemoveStaffCommand, Result>
{
    public Task<Result> Handle(RemoveStaffCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
"@

Create-File "Features\Staff\Queries\Get.cs" @"
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Staff.Queries;

public record GetStaffQuery(Guid VendorId) : IRequest<Result<List<StaffDto>>>;

public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, Result<List<StaffDto>>>
{
    public Task<Result<List<StaffDto>>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<List<StaffDto>>.Success(new List<StaffDto>()));
    }
}
"@

