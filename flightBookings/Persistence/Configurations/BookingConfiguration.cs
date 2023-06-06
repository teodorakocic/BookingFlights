using Domain.Bookings;
using Domain.Purchasers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            booking => booking.Value,
            value => new BookingId(value));

        builder.HasOne<Purchaser>()
            .WithMany()
            .HasForeignKey(b => b.PurchaserId)
            .IsRequired();

        builder.HasMany(b => b.Tickets)
           .WithOne()
           .HasForeignKey(t => t.BookingId);
    }
}
