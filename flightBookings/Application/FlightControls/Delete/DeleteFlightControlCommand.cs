using Domain.FlightControl;
using MediatR;

namespace Application.FlightControls.Delete;

public record DeleteFlightControlCommand(FlightControlId FlightControlId) : IRequest;
