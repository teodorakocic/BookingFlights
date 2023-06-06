using MediatR;

namespace Application.FlightControls.Create;

public record CreateFlightControlCommand(
    DateTime Date,
    string DepartureName,
    string DepartureCode,
    string ArrivalName,
    string ArrivalCode,
    string Gate,
    int Capacity,
    string Model,
    string Number) : IRequest;
