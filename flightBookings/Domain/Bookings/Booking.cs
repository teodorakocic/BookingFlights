using Domain.FlightControl;
using Domain.Purchasers;

namespace Domain.Bookings;

public class Booking
{
    private readonly List<Ticket> _tickets = new();

    private Booking() 
    {

    }

    public BookingId Id { get; private set; }

    public PurchaserId PurchaserId { get; private set; }

    public IReadOnlyList<Ticket> Tickets => _tickets.ToList();

    public static Booking Create(PurchaserId purchaserId, FlightControlId flightControlId, string Currency, decimal Amount, string SeatNumber)
    {
        var booking = new Booking
        {
            Id = new BookingId(Guid.NewGuid()),
            PurchaserId = purchaserId
        };

        booking.Add(flightControlId, new Money(Currency, Amount), new Seat(SeatNumber, true));

        return booking;
    }

    public void Add(FlightControlId flightControlId, Money price, Seat seat)
    {
        var ticket = new Ticket(
            new TicketId(Guid.NewGuid()),
            Id,
            flightControlId,
            price,
            seat);

        _tickets.Add(ticket);
    }

    public void RemoveTicket(TicketId ticketId)
    {
        var ticket = _tickets.FirstOrDefault(t => t.Id == ticketId);

        if (ticket is null)
        {
            return;
        }

        _tickets.Remove(ticket);
    }
}
