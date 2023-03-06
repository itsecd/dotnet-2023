namespace dotNet.classes;
public class Airplane
{
    public string Model { get; set; } = string.Empty;

    public int Load_Capacity { get; set; } = 0;

    public int Perfomance { get; set; } = 0;

    public int Passenger_Capacity { get; set; } = 0;

    public Airplane() { }

    public Airplane(string model, int capacity, int perfomance, int passengers)
    {
        Model = model;
        Load_Capacity = capacity;
        Perfomance = perfomance;
        Passenger_Capacity = passengers;
    }
}
