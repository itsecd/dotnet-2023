namespace Airlines.Domain;

/// <summary>
/// Сlass describing the passenger
/// </summary>
public class PassengerClass
{
    /// <summary>
    /// Represent a unique Id of passanger
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a passport number 
    /// </summary>
    public string? PassportNumber { get; set; }
    /// <summary>
    /// Represent a passenger name
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Represent a tickets 
    /// </summary>
    public List<TicketClass> Tickets { get; set; } = new List<TicketClass>();
    public PassengerClass() { }
    public PassengerClass(string passportNumber, string name)
    {
        PassportNumber = passportNumber;
        Name = name;
    }
}
