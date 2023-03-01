namespace Airlines.Domain;

/// <summary>
/// Сlass describing the passenger
/// </summary>
public class PassengerClass
{
    /// <summary>
    /// Represent a unique Id of passanger
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Represent a passport number 
    /// </summary>
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// Represent a passenger name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Represent a tickets 
    /// </summary>
    public List<TicketClass> Tickets { get; set; } = new List<TicketClass>();
    public PassengerClass() { }
    public PassengerClass(int passportNumber, string name)
    {
        PassportNumber = passportNumber;
        Name = name;
        Tickets = new List<TicketClass>();
    }
}
