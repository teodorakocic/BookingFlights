using MediatR;

namespace Application.Bookings.Create;

public record CreateBookingCommand(Guid PurchaserId, Guid FlightControlId, string Currency, decimal Amount, string SeatNumber) : IRequest;
