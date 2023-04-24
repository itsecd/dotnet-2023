using System.ComponentModel.DataAnnotations;

namespace Airlines.Domain;

/// <summary>
/// Сlass describing the passenger
/// </summary>
public class Passenger
{
    /// <summary>
    /// Represent a unique Id of passanger
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Represent a passport number 
    /// </summary>
    [Required]
    public string? PassportNumber { get; set; }
    /// <summary>
    /// Represent a passenger name
    /// </summary>
    [Required]
    public string? Name { get; set; }
    /// <summary>
    /// Represent a tickets 
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public Passenger() { }
    public Passenger(string passportNumber, string name)
    {
        PassportNumber = passportNumber;
        Name = name;
    }
}