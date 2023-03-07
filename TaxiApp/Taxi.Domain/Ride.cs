namespace Taxi.Domain;

public class Ride
{
    public UInt64 Id { get; set; }
    
    public string DeparturePoint { get; set; } = String.Empty;

    public string DestinationPoint { get; set; } = String.Empty;
    
    public DateTime RideDate { get; set; }
    
    public TimeOnly RideTime { get; set; }

    public UInt32 Cost { get; set; } = 0;

    public UInt64 PassengerId { get; set; } 

    public UInt64 VehicleId { get; set; } 
    
    public Ride() { }

    public Ride(UInt64 id, string departurePoint, string destinationPoint, DateTime rideDate, TimeOnly rideTime,
        UInt32 cost, UInt64 passenger, UInt64 vehicle)
    {
        Id = id;
        DeparturePoint = departurePoint;
        DestinationPoint = destinationPoint;
        RideDate = rideDate;
        RideTime = rideTime;
        Cost = cost;
        PassengerId = passenger;
        VehicleId = vehicle;
    }

}