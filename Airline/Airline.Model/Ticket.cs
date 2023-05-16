using System.ComponentModel.DataAnnotations;

namespace AirLine.Model;
public class Ticket
{
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Ticket number
    /// </summary>
    [Required]
    public int Number { get; set; } = 0;
    /// <summary>
    /// Seat number
    /// </summary>
    [Required]
    public string SeatNumber { get; set; } = string.Empty;
    /// <summary>
    /// Baggage weight
    /// </summary>
    [Required]
    public double BaggageWeight { get; set; } = 0;
    /// <summary>
    /// Passenger id
    /// </summary>
    [Required]
    public int PassengerId { get; set; } = 0;
    public Ticket() { }

    public Ticket(int id, int number = 0, string seatNumber = "", double baggageWeight = 0, int passengerId = 0)
    {
        Id = id;
        Number = number;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
        PassengerId = passengerId;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Ticket param)
            return false;

        return Number == param.Number &&
               SeatNumber == param.SeatNumber &&
               BaggageWeight == param.BaggageWeight &&
               PassengerId == param.PassengerId;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}
