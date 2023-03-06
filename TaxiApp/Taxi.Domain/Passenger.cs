namespace Taxi.Domain;

public class Passenger
{
    public UInt64 Id { get; set; } 

    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
    
    public string? Patronymic { get; set; }
    
    public string PhoneNumber { get; set; } = String.Empty;

    public List<Ride> Rides { get; set; } = new();

    public Passenger() { }
    public Passenger(UInt64 id, string firstName, string lastName, string patronymic, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Rides = new List<Ride>();
    }
}
