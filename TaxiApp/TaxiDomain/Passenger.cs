namespace TaxiDomain;

public class Passenger
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
    
    public string? Patronymic { get; set; }
    
    public string PhoneNumber { get; set; } = String.Empty;

    public List<Ride> Rides { get; set; } = new();
    
}