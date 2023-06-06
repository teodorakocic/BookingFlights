using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Bookings.Create;

internal sealed class CreatePaymentRequestEventHandler
    : INotificationHandler<BookingCreatedEvent>
{
    private readonly ILogger<CreatePaymentRequestEventHandler> _logger;

    public CreatePaymentRequestEventHandler(ILogger<CreatePaymentRequestEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(BookingCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting payment request {@BookingId}", notification.BookingId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation("Payment request started {@BookingId}", notification.BookingId);
    }
}
