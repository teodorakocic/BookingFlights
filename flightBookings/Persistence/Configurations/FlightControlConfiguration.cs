using Domain.FlightControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class FlightControlConfiguration : IEntityTypeConfiguration<FlightControl>
    {
        public void Configure(EntityTypeBuilder<FlightControl> builder)
        {
            builder.HasKey(fc => fc.Id);

            builder.Property(fc => fc.Id).HasConversion(
                flightControl => flightControl.Value,
                value => new FlightControlId(value));

            builder.Property(fc => fc.Date);

            builder.OwnsOne(fc => fc.Departure, departureBuilder =>
            {
                departureBuilder.Property(a => a.Name).HasMaxLength(100);
                departureBuilder.Property(a => a.Code).HasMaxLength(3);
            });

            builder.OwnsOne(fc => fc.Arrival, arrivalBuilder =>
            {
                arrivalBuilder.Property(a => a.Name).HasMaxLength(100);
                arrivalBuilder.Property(a => a.Code).HasMaxLength(3);
            });

            builder.Property(fc => fc.Gate).HasMaxLength(5);

            builder.OwnsOne(fc => fc.Plane, planeBuilder =>
            {
                planeBuilder.Property(p => p.Capacity);
                planeBuilder.Property(p => p.Model).HasMaxLength(100);
            });

            builder.Property(fc => fc.Number);

            builder.HasIndex(fc => fc.Number).IsUnique();
        }
    }
}
