namespace TaxiDomain;

public class Driver
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
    
    public string? Patronymic { get; set; }
    
    public string Passport { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;
    
}