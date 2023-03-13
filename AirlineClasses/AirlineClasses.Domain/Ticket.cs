using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Domain;
public class Ticket
{
    public int Number { get; set; } = 0;
    public string SeatNumber { get; set; } = string.Empty;
    public double BaggageWeight { get; set; } = 0;
    public Ticket() { }

    public Ticket(int number = 0, string seatNumber = "", double baggageWeight = 0)
    {
        Number = number;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Ticket param)
            return false;

        return Number == param.Number &&
               SeatNumber == param.SeatNumber &&
               BaggageWeight == param.BaggageWeight;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}
