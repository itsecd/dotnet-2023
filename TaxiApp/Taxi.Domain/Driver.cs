namespace Taxi.Domain;

public class Driver
{
    public UInt64 Id { get; set; }

    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
    
    public string? Patronymic { get; set; }
    
    public string Passport { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;
    
    public Driver() { }

    public Driver(UInt64 id, string firstName, string lastName, string? patronymic, string passport, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Passport = passport;
        PhoneNumber = phoneNumber;
    }
}