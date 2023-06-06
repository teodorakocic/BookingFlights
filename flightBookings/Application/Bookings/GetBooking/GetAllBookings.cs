using Domain.Bookings;
using Domain.Purchasers;
using MediatR;

namespace Application.Bookings.GetBooking;

public record GetAllBookings(PurchaserId PurchaserId) : IRequest<List<Booking>>;
