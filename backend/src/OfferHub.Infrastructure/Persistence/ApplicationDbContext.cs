using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OfferHub.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<OfferHub.Domain.Entities.AuditLog> AuditLogs { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Banner> Banners { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Branch> Branches { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Category> Categories { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.CmsContent> CmsContents { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Favorite> Favorites { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Notification> Notifications { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Offer> Offers { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.OfferBranch> OfferBranches { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.OfferClaim> OfferClaims { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.OfferImage> OfferImages { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.OfferRedemption> OfferRedemptions { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Payment> Payments { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Permission> Permissions { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Role> Roles { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.RolePermission> RolePermissions { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.SubscriptionPlan> SubscriptionPlans { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.User> Users { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.UserRole> UserRoles { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.Vendor> Vendors { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.VendorStaff> VendorStaff { get; set; } = null!;
    public DbSet<OfferHub.Domain.Entities.VendorSubscription> VendorSubscriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => !t.GetInterfaces().Contains(typeof(IEntityTypeConfiguration<object>))
        );

        modelBuilder.Entity<OfferHub.Domain.Entities.Branch>().OwnsOne(b => b.Location);
        modelBuilder.Entity<OfferHub.Domain.Entities.OfferClaim>().OwnsOne(o => o.CouponCode);
        modelBuilder.Entity<OfferHub.Domain.Entities.Payment>().OwnsOne(p => p.Amount);
        modelBuilder.Entity<OfferHub.Domain.Entities.SubscriptionPlan>().OwnsOne(s => s.Price);
        modelBuilder.Entity<OfferHub.Domain.Entities.User>().OwnsOne(u => u.Email);
        modelBuilder.Entity<OfferHub.Domain.Entities.Vendor>().OwnsOne(v => v.ContactEmail);

        modelBuilder.Ignore<OfferHub.Domain.Common.IDomainEvent>();

        base.OnModelCreating(modelBuilder);
    }
}