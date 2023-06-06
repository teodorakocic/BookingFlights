using Domain.Purchasers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class PurchaserConfiguration : IEntityTypeConfiguration<Purchaser>
{
    public void Configure(EntityTypeBuilder<Purchaser> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            purchaserId => purchaserId.Value,
            value => new PurchaserId(value));

        builder.Property(p => p.FirstName).HasMaxLength(100);

        builder.Property(p => p.LastName).HasMaxLength(100);

        builder.Property(p => p.Email).HasMaxLength(255);

        builder.HasIndex(p => p.Email).IsUnique();
    }
}
