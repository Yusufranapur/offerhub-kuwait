using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Replace 'object' with the actual domain entity 'Category'
        builder.ToTable("Categorys");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
        // builder.Pr