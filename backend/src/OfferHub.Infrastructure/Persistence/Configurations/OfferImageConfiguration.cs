using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class OfferImageConfiguration : IEntityTypeConfiguration<OfferImage>
{
    public void Configure(EntityTypeBuilder<OfferImage> builder)
    {
        // Replace 'object' with the actual domain entity 'OfferImage'
        builder.ToTable("OfferImages");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
        // builder.Property(e => e.UpdatedAt).IsRequired(false);
    }
}
