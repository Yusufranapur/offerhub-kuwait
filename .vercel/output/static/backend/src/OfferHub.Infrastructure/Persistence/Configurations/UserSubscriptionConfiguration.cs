using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        // Replace 'object' with the actual domain entity 'UserSubscription'
        builder.ToTable("UserSubscriptions");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
     