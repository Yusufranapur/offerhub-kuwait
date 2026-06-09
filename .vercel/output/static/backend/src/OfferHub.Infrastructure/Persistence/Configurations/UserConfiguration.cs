using OfferHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfferHub.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Replace 'object' with the actual domain entity 'User'
        builder.ToTable("Users");
        // builder.HasKey(e => e.Id);
        // builder.Property(e => e.Id).HasColumnType("uuid");
        // builder.Property(e => e.CreatedAt).IsRequired();
        // builder.Property(e