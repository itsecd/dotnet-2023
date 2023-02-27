namespace Airlines.Domain;
public class TicketClass // пример про школу (15варинат) 
{
    public int TicketNumber { get; set; }
    public string SeatNumber { get; set; }
    public int BaggageWeight { get; set;}
    public TicketClass(int ticketNumber, string seatNumber, int baggageWeight)
    {
        TicketNumber = ticketNumber;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
    }
}
