namespace AirlineClasses;
public class Airplane
{
    /// <summary>
    /// Airplane model
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Airplane load capacity
    /// </summary>
    public int Load_Capacity { get; set; } = 0;
    /// <summary>
    /// Airplane perfomance
    /// </summary>
    public int Perfomance { get; set; } = 0;
    /// <summary>
    /// Airplane passengers capacity
    /// </summary>
    public int Passenger_Capacity { get; set; } = 0;

    public Airplane() { }

    public Airplane(string model, int capacity, int perfomance, int passengers)
    {
        Model = model;
        Load_Capacity = capacity;
        Perfomance = perfomance;
        Passenger_Capacity = passengers;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Airplane param)
            return false;

        return Model == param.Model &&
               Load_Capacity == param.Load_Capacity &&
               Perfomance == param.Perfomance &&
               Passenger_Capacity == param.Passenger_Capacity;
                
    }
}
