using Domain.FlightControl;

namespace Domain.Bookings;

public class Ticket
{

    internal Ticket(TicketId id, BookingId bookingId, FlightControlId flightControlId, Money price, Seat seat)
    {
        Id = id;
        BookingId = bookingId;
        FlightControlId = flightControlId;
        Price = price;
        Seat = seat;
    }

    private Ticket() 
    {

    }

    public TicketId Id { get; private set; }

    public BookingId BookingId { get; private set; }

    public FlightControlId FlightControlId { get; private set; }

    public Money Price { get; private set; }

    public Seat Seat { get; private set; }
}
