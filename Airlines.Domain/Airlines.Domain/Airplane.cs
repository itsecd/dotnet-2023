namespace Airlines.Domain;

public class AirplaneClass 
{
    public string Model { get; set; }
    public int CarryingCapacity { get; set; }
    public int Capability { get; set; }
    public int SeatingCapacity { get; set; }
    public List<FlightCLass> Flights { get; set; }
    public AirplaneClass(string model,int carryingcapacity,int capability,int seatingcapacity)
    {
        Model=model;
        CarryingCapacity=carryingcapacity; 
        Capability=capability;
        SeatingCapacity = seatingcapacity;
        Flights = new List<FlightCLass>();
    }
}
