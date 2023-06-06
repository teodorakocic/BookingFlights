using Application.Bookings.Create;
using Application.Data;
using Domain.Bookings;
using Domain.FlightControl;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Bookings.AddTicket;

internal sealed class AddTicketToBookingCommandHandler : IRequestHandler<AddTicketToBooking>
{

    private readonly IApplicationDbContext _context;
    private readonly IPublisher _publisher;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<FlightControl> _flightControlRepository;

    public AddTicketToBookingCommandHandler(
        IApplicationDbContext context,
        IPublisher publisher,
        IRepository<Booking> bookingsRepository,
        IRepository<FlightControl> flightControlRepository)
    {
        _context = context;
        _publisher = publisher;
        _bookingRepository = bookingsRepository;
        _flightControlRepository = flightControlRepository;
    }

    public async Task Handle(AddTicketToBooking request, CancellationToken cancellationToken)
    {

        var bookings = await _context.Bookings.Include(t => t.Tickets).ToListAsync(cancellationToken);

        var booking = await _bookingRepository.GetByIdAsync(request.BookingId.Value);

        var flightControl = await _flightControlRepository.GetByIdAsync(request.FlightControlId.Value);

        if (booking is null || flightControl is null)
        {
            return; 
        }

        var seatBooked = false;

        for(var i = 0; i < bookings.Count; i++)
        {
            for(var j= 0; j < bookings[i].Tickets.Count; j++)
            {
                if ((bookings[i].Tickets[j].Seat.Number.Equals(request.SeatNumber)) && (bookings[i].Tickets[j].FlightControlId == request.FlightControlId))
                {
                    seatBooked= true;
                    break;
                }
            }
        }

        if(!seatBooked)
        {
            booking.Add(request.FlightControlId, new Money(request.Currency, request.Amount), new Seat(request.SeatNumber, true));
            await _context.SaveChangesAsync();
            await _publisher.Publish(new BookingCreatedEvent(booking.Id), cancellationToken);
        } else
        {
            await _publisher.Publish(new BookingRejectedEvent(booking.Id), cancellationToken);
            throw new Exception("Seat has been already booked for this flight!");
        }
    }
}
