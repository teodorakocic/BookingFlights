using Domain.Bookings;
using MediatR;

namespace Application.Bookings.RemoveTicket;

public record RemoveTicket(BookingId BookingId, TicketId TicketId) : IRequest;
