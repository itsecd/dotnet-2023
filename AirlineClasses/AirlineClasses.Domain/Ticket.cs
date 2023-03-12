using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineClasses;
public class Ticket
{
    public int Number { get; set; } = 0;
    public string Seat_number { get; set; } = string.Empty;
    public double Baggage_weight { get; set; } = 0;
    public Ticket() { }

    public Ticket(int number = 0, string seat_number = "", double baggage_weight = 0)
    {
        Number = number;
        Seat_number = seat_number;
        Baggage_weight = baggage_weight;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Ticket param)
            return false;

        return Number == param.Number &&
               Seat_number == param.Seat_number &&
               Baggage_weight == param.Baggage_weight;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}
