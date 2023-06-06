using Application.Data;
using Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;
 
namespace Application.Bookings.GetBooking;

internal class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookings, List<Booking>>
{
    private readonly IApplicationDbContext _context;

    public GetAllBookingsQueryHandler(IApplicationDbContext context, IRepository<Booking> bookingRepository)
    {
        _context = context;
    }

    public async Task<List<Booking>> Handle(GetAllBookings request, CancellationToken cancellationToken)
    {
        var bookings = await _context.Bookings.Where(b => b.PurchaserId ==  request.PurchaserId).Include(t => t.Tickets).ToListAsync(cancellationToken);

        return bookings is null ? throw new Exception("Purchaser with given id hasn't booked any trip yet!") : bookings;
    }
}

