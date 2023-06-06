using MediatR;

namespace Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId): IRequest<BookingResponse>;
