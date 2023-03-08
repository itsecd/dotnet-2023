namespace Taxi.Domain;

public class Ride
{
    public UInt64 Id { get; set; }
    
    public string DeparturePoint { get; set; } = String.Empty;

    public string DestinationPoint { get; set; } = String.Empty;

    public DateTime RideDate { get; set; } = new DateTime();

    public TimeOnly RideTime { get; set; } = new TimeOnly();

    public UInt32 Cost { get; set; } = 0;

    public UInt64 PassengerId { get; set; } 

    public UInt64 VehicleId { get; set; } 

}