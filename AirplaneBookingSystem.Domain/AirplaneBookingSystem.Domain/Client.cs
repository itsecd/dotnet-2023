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
    /// Client`s passport number 
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;
    /// <summary>
    /// Client`s birthday
    /// </summary>
    public DateTime BirthdayData { get; set; } = new DateTime();
    /// <summary>
    /// Client`s name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Client`s tickets 
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public Client() { }
    public Client(string passportNumber, DateTime birthdayData, string name)
    {
        PassportNumber = passportNumber;
        BirthdayData = birthdayData;
        Name = name;
    }
}
