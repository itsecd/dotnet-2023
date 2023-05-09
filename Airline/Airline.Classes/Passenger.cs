using System.ComponentModel.DataAnnotations;

namespace AirLine.Model;
public class Passenger
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Passenger passport ID
    /// </summary>
    [Required]
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// Passenger name
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Create default passenger object
    /// </summary>
    public Passenger() { }

    /// <summary>
    /// Create passenger object by name and passport ID
    /// </summary>
    public Passenger(int id, int passport_number, string name)
    {
        this.Id = id;
        this.PassportNumber = passport_number;
        this.Name = name;
    }
    /// <summary>
    /// Create passenger object by name, passport ID, ticket number, seat number and baggage weight
    /// for registered on flight passengers
    /// </summary>
    public Passenger(int id, int passport_number, string name, List<Ticket> tickets)
    {
        this.Id = id;
        PassportNumber = passport_number;
        this.Name = name;
    }


    public override bool Equals(object? obj)
    {
        if (obj is not Passenger param)
            return false;

        return PassportNumber == param.PassportNumber &&
               Name == param.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, PassportNumber);
    }
}
