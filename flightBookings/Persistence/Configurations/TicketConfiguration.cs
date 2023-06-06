using Domain.Bookings;
using Domain.FlightControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).HasConversion(
            ticketId => ticketId.Value,
            value => new TicketId(value));

        builder.HasOne<FlightControl>()
            .WithMany()
            .HasForeignKey(t => t.FlightControlId);

        builder.OwnsOne(t => t.Price);

        builder.OwnsOne(t => t.Seat, seatBuilder =>
        {
            seatBuilder.Property(s => s.Number).HasMaxLength(6);
            seatBuilder.Property(s => s.Occupied);
        });
    }
}
