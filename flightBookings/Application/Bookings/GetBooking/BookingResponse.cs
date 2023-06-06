namespace Application.Bookings.GetBooking;

public record BookingResponse(Guid Id, Guid PurchaserId, List<TicketResponse> Tickets);
