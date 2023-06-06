using Application.Data;
using Application.FlightControls.Create;
using Domain.FlightControl;
using MediatR;

namespace Application.FligtControls.Create;

internal class CreateFlightControlCommandQueryHandler : IRequestHandler<CreateFlightControlCommand>
{

    private readonly IRepository<FlightControl> _flightControlRepository;

    public CreateFlightControlCommandQueryHandler(IRepository<FlightControl> flightControlRepository)
    {
        _flightControlRepository = flightControlRepository;
    }

    public async Task Handle(CreateFlightControlCommand request, CancellationToken cancellationToken)
    {
        var flightControl = new FlightControl(
            new FlightControlId(Guid.NewGuid()),
            request.Date,
            new Airport(request.DepartureName, request.DepartureCode),
            new Airport(request.ArrivalName, request.ArrivalCode),
            request.Gate,
            new Plane(request.Capacity, request.Model),
            request.Number);

        _flightControlRepository.Insert(flightControl);

        await _flightControlRepository.SaveChangesAsync();
    }
}
