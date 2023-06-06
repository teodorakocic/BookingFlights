using Domain.FlightControl;
using MediatR;

namespace Application.FlightControls.Read;

public record ReadFlightControlQuery(FlightControlId FlightControlId) : IRequest<FlightControlResponse>;

public record FlightControlResponse(
    Guid Id,
    DateTime Date,
    string DepartureName,
    string DepartureCode,
    string ArrivalName,
    string ArrivalCode,
    string Gate,
    int Capacity,
    string Model,
    string Number);
