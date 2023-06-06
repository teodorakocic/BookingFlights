using Domain.Bookings;
using MediatR;

namespace Application.Bookings.Create;

public record BookingRejectedEvent(BookingId BookingId) : INotification;
