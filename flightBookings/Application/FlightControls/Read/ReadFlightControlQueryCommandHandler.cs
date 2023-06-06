using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlightControls.Read;

internal sealed class ReadFlightControlQueryCommandHandler : IRequestHandler<ReadFlightControlQuery, FlightControlResponse>
{
    private readonly IApplicationDbContext _context;

    public ReadFlightControlQueryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FlightControlResponse> Handle(ReadFlightControlQuery request, CancellationToken cancellationToken)
    {
        var flightControl = await _context
            .FlightControls
            .Where(f => f.Id == request.FlightControlId)
            .Select(f => new FlightControlResponse(
                f.Id.Value,
                f.Date,
                f.Departure.Name,
                f.Departure.Code,
                f.Arrival.Name,
                f.Arrival.Code,
                f.Gate,
                f.Plane.Capacity,
                f.Plane.Model,
                f.Number))
            .FirstOrDefaultAsync(cancellationToken);

        if(flightControl is null)
        {
            throw new Exception("Flight with given id is not found!");
        }

        return flightControl;
    }
}
