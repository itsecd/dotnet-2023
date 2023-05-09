using System.ComponentModel.DataAnnotations;

namespace AirLine.Model;
public class Airplane
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Airplane model
    /// </summary>
    [Required]
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Airplane load capacity
    /// </summary>
    [Required]
    public int LoadCapacity { get; set; } = 0;
    /// <summary>
    /// Airplane perfomance
    /// </summary>
    [Required]
    public int Perfomance { get; set; } = 0;
    /// <summary>
    /// Airplane passengers capacity
    /// </summary>
    [Required]
    public int PassengerCapacity { get; set; } = 0;

    public Airplane() { }

    public Airplane(int id, string model, int capacity, int perfomance, int passengers)
    {
        Id = id;
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
