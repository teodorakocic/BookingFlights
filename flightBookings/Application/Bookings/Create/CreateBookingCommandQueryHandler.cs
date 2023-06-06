using Application.Data;
using Domain.Bookings;
using Domain.FlightControl;
using Domain.Purchasers;
using MediatR;

namespace Application.Bookings.Create;

internal sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IPublisher _publisher;
    private readonly IRepository<Purchaser> _purchasersRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<FlightControl> _flightControlRepository;

    public CreateBookingCommandHandler(
        IApplicationDbContext context,
        IPublisher publisher,
        IRepository<Purchaser> purchasersRepository,
        IRepository<Booking> bookingsRepository,
        IRepository<FlightControl> flightControlRepository)
    {
        _context = context;
        _publisher = publisher;
        _purchasersRepository = purchasersRepository;
        _bookingRepository = bookingsRepository;
        _flightControlRepository = flightControlRepository;
    }

    public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var purchaser = await _purchasersRepository.GetByIdAsync(request.PurchaserId);

        var flightControl = await _flightControlRepository.GetByIdAsync(request.FlightControlId);

        if (purchaser is null || flightControl is null)
        {
            return;
        }

        var booking = Booking.Create(purchaser.Id, flightControl.Id, request.Currency, request.Amount, request.SeatNumber);

        _bookingRepository.Insert(booking);

        await _bookingRepository.SaveChangesAsync();

        await _publisher.Publish(new BookingCreatedEvent(booking.Id), cancellationToken);
    }
}
