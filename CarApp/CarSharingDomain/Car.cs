namespace CarSharingDomain;
/// <summary>
/// this class describes all cars which can be rented in rental points
/// </summary>
public class Car
{
    /// <summary>
    /// model of the car
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// colour of the car
    /// </summary>
    public string Colour { get; set; } = string.Empty;
    /// <summary>
    /// number of the car
    /// </summary>
    public string Number { get; set; } = string.Empty;
    /// <summary>
    /// id of the car
    /// </summary>
    public uint CarId { get; set; }
    public Car() { }
    public Car(uint carId, string model, string colour, string number)
    {
        CarId = carId;
        Model = model;
        Colour = colour;
        Number = number;
    }
}
