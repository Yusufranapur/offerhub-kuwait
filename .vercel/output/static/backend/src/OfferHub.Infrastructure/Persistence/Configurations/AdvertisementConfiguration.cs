using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        // Replace 'object' with the actual domain entity 'Advertisement'
        builder.ToTable("Advertisements");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
        // 