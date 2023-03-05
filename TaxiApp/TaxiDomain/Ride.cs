namespace TaxiDomain;

public class Ride
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string DeparturePoint { get; set; } = String.Empty;

    public string DestinationPoint { get; set; } = String.Empty;
    
    public DateTime RideDate { get; set; }
    
    public TimeOnly RideTime { get; set; }

    public UInt32 Cost { get; set; } = 0;

    public Passenger Passenger { get; set; } = new Passenger();

    public Vehicle Vehicle { get; set; } = new Vehicle();

}