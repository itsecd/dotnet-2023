using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet.classes;
public class Passenger
{
    /// <summary>
    /// Passenger passport ID
    /// </summary>
    public int Passport_number { get; set; } = 0;
    /// <summary>
    /// Passenger name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Passenger's ticket number
    /// </summary>
    public int Ticket_number { get; set; } = 0;
    /// <summary>
    /// Passenger's seat number
    /// </summary>
    public int Seat_number { get; set; } = 0;         
    /// <summary>
    /// Passenger's baggage weight
    /// </summary>
    public float Baggage_weight { get; set; } = 0;
    /// <summary>
    /// Create default passenger object
    /// </summary>
    public Passenger() {}

    /// <summary>
    /// Create passenger object by name and passport ID
    /// </summary>
    public Passenger(int passport_number, string name)
    {
        Passport_number = passport_number;
        Name = name;
    }
    /// <summary>
    /// Create passenger object by name, passport ID, ticket number, seat number and baggage weight
    /// </summary>
    public Passenger(int passport_number, string name, int ticket_number, int seat_number, float baggage_weight)
    {
        Passport_number = passport_number;
        Name = name;
        Ticket_number = ticket_number;
        Seat_number = seat_number;
        Baggage_weight = baggage_weight;
    }
}
