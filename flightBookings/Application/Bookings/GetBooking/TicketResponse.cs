namespace Application.Bookings.GetBooking;

public record TicketResponse(Guid TicketId, decimal Price, string Number);
