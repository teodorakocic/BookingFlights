using Domain.Bookings;
using Domain.FlightControl;
using MediatR;

namespace Application.Bookings.AddTicket;

public record AddTicketToBooking(BookingId BookingId, FlightControlId FlightControlId, string Currency, decimal Amount, string SeatNumber) : IRequest;
