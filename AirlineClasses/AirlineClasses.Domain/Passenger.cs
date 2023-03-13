using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Domain;
public class Passenger
{
    /// <summary>
    /// Passenger passport ID
    /// </summary>
    public int PassportNumber { get; set; } = 0;
    /// <summary>
    /// Passenger name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// List of tickets for passenger
    /// </summary>
    public List<Ticket>? Tickets { get; set; }
    /// <summary>
    /// Create default passenger object
    /// </summary>
    public Passenger() {}

    /// <summary>
    /// Create passenger object by name and passport ID
    /// </summary>
    public Passenger(int passport_number, string name)
    {
        PassportNumber = passport_number;
        this.Name = name;
    }
    /// <summary>
    /// Create passenger object by name, passport ID, ticket number, seat number and baggage weight
    /// for registered on flight passengers
    /// </summary>
    public Passenger(int passport_number, string name, List<Ticket> tickets)
    {
        PassportNumber = passport_number;
        this.Name = name;
        Tickets = tickets;
    }

    /// <summary>
    /// add ticket to ticket list
    /// </summary>
    /// <param name="ticket"></param>
    public void Add_ticket(Ticket ticket)
    {
        Tickets.Add(ticket);
    }
    /// <summary>
    /// add ticket list to ticket list
    /// </summary>
    /// <param name="tickets"></param>
    public void Add_ticket(List<Ticket> tickets)
    {
        Tickets.AddRange(tickets);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Passenger param)
            return false;

        return PassportNumber == param.PassportNumber &&
               Name == param.Name &&
               Tickets == param.Tickets;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, PassportNumber);
    }
}
