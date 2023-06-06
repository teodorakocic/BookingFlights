using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Bookings.RemoveTicket;

internal sealed class RemoveTicketCommandHandler : IRequestHandler<RemoveTicket>
{
    private readonly IApplicationDbContext _context;

    public RemoveTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveTicket request, CancellationToken cancellationToken)
    {
        var booking = await _context
            .Bookings
            .Include(b => b.Tickets.Where(t => t.Id == request.TicketId))
            .SingleOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            return;
        }

        booking.RemoveTicket(request.TicketId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
