using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Bookings.Create;

internal sealed class SendBookingConfirmationEventHandler
    : INotificationHandler<BookingCreatedEvent>
{
    private readonly ILogger<SendBookingConfirmationEventHandler> _logger;

    public SendBookingConfirmationEventHandler(ILogger<SendBookingConfirmationEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(BookingCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending order confirmation {@BookingId}", notification.BookingId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation("Order confirmation sent {@BookingId}", notification.BookingId);
    }
}
