using Application.Data;
using Domain.Bookings;
using Domain.FlightControl;
using Domain.Purchasers;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Purchaser> Purchasers{ get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<FlightControl> FlightControls { get; set; }

    public DbSet<Ticket> Tickets { get; set; }
}
