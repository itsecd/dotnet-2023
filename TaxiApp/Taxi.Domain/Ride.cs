namespace Taxi.Domain;

public class Ride
{
    public UInt64 Id { get; set; }
    
    public string DeparturePoint { get; set; } = String.Empty;

    public string DestinationPoint { get; set; } = String.Empty;
    
    public DateTime RideDate { get; set; }
    
    public TimeOnly RideTime { get; set; }

    public UInt32 Cost { get; set; } = 0;

    public Passenger Passenger { get; set; } = new Passenger();

    public Vehicle Vehicle { get; set; } = new Vehicle();
    
    public Ride() { }

    public Ride(UInt64 id, string departurePoint, string destinationPoint, DateTime rideDate, TimeOnly rideTime,
        UInt32 cost, Passenger passenger, Vehicle vehicle)
    {
        Id = id;
        DeparturePoint = departurePoint;
        DestinationPoint = destinationPoint;
        RideDate = rideDate;
        RideTime = rideTime;
        Cost = cost;
        Passenger = passenger;
        Vehicle = vehicle;
    }

}