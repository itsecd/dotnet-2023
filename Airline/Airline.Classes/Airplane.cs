namespace AirLine.Domain;
public class Airplane
{
    /// <summary>
    /// Airplane model
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Airplane load capacity
    /// </summary>
    public int LoadCapacity { get; set; } = 0;
    /// <summary>
    /// Airplane perfomance
    /// </summary>
    public int Perfomance { get; set; } = 0;
    /// <summary>
    /// Airplane passengers capacity
    /// </summary>
    public int PassengerCapacity { get; set; } = 0;

    public Airplane() { }

    public Airplane(string model, int capacity, int perfomance, int passengers)
    {
        Model = model;
        LoadCapacity = capacity;
        Perfomance = perfomance;
        PassengerCapacity = passengers;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Airplane param)
            return false;

        return Model == param.Model &&
               LoadCapacity == param.LoadCapacity &&
               Perfomance == param.Perfomance &&
               PassengerCapacity == param.PassengerCapacity;
                
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode();
    }
}
