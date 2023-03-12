namespace AirplaneBookingSystem.Domain;

/// <summary>
/// Сlass describing the client
/// </summary>
public class Client
{
    /// <summary>
    /// Unique Id of client
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Passport number 
    /// </summary>
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// Client`s birthday
    /// </summary>
    public DateOnly BirthdayData { get; set; } = new DateOnly();
    /// <summary>
    /// Client`s name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Represent a tickets 
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public Client() { }
    public Client(int passportNumber, DateOnly birthdayData, string name)
    {
        PassportNumber = passportNumber;
        BirthdayData = birthdayData;
        Name = name;
        Tickets = new List<Ticket>();
    }
}
