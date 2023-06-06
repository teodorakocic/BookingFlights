using Domain.Bookings;
using MediatR;

namespace Application.Bookings.Create;

public record BookingCreatedEvent(BookingId BookingId) : INotification;
