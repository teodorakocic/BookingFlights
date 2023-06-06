using Application.Data;
using Domain.FlightControl;
using MediatR;

namespace Application.FlightControls.Delete;

internal sealed class DeleteFlightControlCommandQueryHandler : IRequestHandler<DeleteFlightControlCommand>
{

    private readonly IRepository<FlightControl> _flightRepository;

    public DeleteFlightControlCommandQueryHandler(IRepository<FlightControl> flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task Handle(DeleteFlightControlCommand request, CancellationToken cancellationToken)
    {
        var flightControl = await _flightRepository.GetByIdAsync(request.FlightControlId.Value);

        if (flightControl is null)
        {
            throw new ArgumentException("Flight control with given id does not exist!");
        }

        _flightRepository.Delete(flightControl);

        await _flightRepository.SaveChangesAsync();
    }
}
