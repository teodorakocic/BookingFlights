using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Bookings.Create;

internal sealed class SendBookingRejectedEventHandler : INotificationHandler<BookingRejectedEvent>
{

    private readonly ILogger<SendBookingRejectedEventHandler> _logger;

    public SendBookingRejectedEventHandler(ILogger<SendBookingRejectedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(BookingRejectedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending booking rejected {@BookingId}", notification.BookingId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation("Booking rejected sent {@BookingId}", notification.BookingId);
    }
}
