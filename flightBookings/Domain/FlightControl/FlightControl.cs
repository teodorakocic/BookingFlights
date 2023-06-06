namespace Domain.FlightControl;

public class FlightControl
{
    public FlightControl(FlightControlId id, DateTime date, Airport departure, Airport arrival, string gate, Plane plane, string number)
    {
        Id = id;
        Date = date;
        Departure = departure;
        Arrival = arrival;
        Gate = gate;
        Plane = plane;
        Number = number;
    }

    private FlightControl()
    {

    }

    public FlightControlId Id { get; private set; }

    public DateTime Date { get; private set; } = DateTime.Now;

    public Airport Departure { get; private set; }

    public Airport Arrival { get; private set; }

    public string Gate { get; private set; } = string.Empty;

    public Plane Plane { get; private set; }

    public string Number { get; private set; } = string.Empty;
}
