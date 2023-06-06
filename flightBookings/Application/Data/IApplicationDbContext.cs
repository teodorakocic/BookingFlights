using Domain.Bookings;
using Domain.FlightControl;
using Domain.Purchasers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Purchaser> Purchasers { get; set; }

    DbSet<Booking> Bookings { get; set; }

    DbSet<FlightControl> FlightControls { get; set; }

    DbSet<Ticket> Tickets { get; set; }

    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
