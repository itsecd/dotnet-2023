namespace Airlines.Domain;
public class FlightCLass // пример про школу (15варинат) 
{
    public int Number { get; set; }
    public string FlightCode { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public int FlightDuration { get; set; }
    public string AirplaneType { get; set; }
    public List<TicketClass> Tickets { get; set; }

    public FlightCLass(int number,string flightcode,string source,
        string destination,DateOnly departuredate,
        DateOnly arrivaldate,int flightduration,string airplanetype){
        Number = number;
        FlightCode = flightcode;
        Source = source;
        Destination = destination;
        DepartureDate = departuredate;
        ArrivalDate = arrivaldate;
        FlightDuration = flightduration;
        AirplaneType = airplanetype;
        Tickets = new List<TicketClass>();
    }
}
