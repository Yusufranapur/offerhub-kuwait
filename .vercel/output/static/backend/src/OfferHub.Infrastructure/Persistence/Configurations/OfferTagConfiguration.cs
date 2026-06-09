using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class OfferTagConfiguration : IEntityTypeConfiguration<OfferTag>
{
    public void Configure(EntityTypeBuilder<OfferTag> builder)
    {
        // Replace 'object' with the actual domain entity 'OfferTag'
        builder.ToTable("OfferTags");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
        // builder.Pr