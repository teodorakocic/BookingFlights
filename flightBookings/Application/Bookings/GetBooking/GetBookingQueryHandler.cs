using Application.Data;
using Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler :
    IRequestHandler<GetBookingQuery, BookingResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IRepository<Booking> _bookingRepository;

    public GetBookingQueryHandler(IApplicationDbContext context, IRepository<Booking> bookingRepository)
    {
        _context = context;
        _bookingRepository = bookingRepository;
    }

    public async Task<BookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        var bookingResponse = await _bookingRepository
            .GetQueryable()
            .Where(b => b.Id == new BookingId(request.BookingId))
            .Select(b => new BookingResponse(
                b.Id.Value,
                b.PurchaserId.Value,
                b.Tickets
                    .Select(t => new TicketResponse(t.Id.Value, t.Price.Amount, t.Seat.Number))
                    .ToList()))
            .SingleAsync(cancellationToken);

        return bookingResponse;
    }
}
