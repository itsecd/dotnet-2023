using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet.classes;
public class Passenger
{
    public int Passport_number { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Ticket_number { get; set; } = 0;
    public int Seat_number { get; set; } = 0;
    public float Baggage_weight { get; set; } = 0;
    public Passenger() {}

    public Passenger(int passport_number, string name)
    {
        Passport_number = passport_number;
        Name = name;
    }
    public Passenger(int passport_number, string name, int ticket_number, int seat_number, float baggage_weight)
    {
        Passport_number = passport_number;
        Name = name;
        Ticket_number = ticket_number;
        Seat_number = seat_number;
        Baggage_weight = baggage_weight;
    }
}
